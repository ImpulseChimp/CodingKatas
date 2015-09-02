{
    init: function(elevators, floors) {

        var WEIGHT_FILTER = 0.7;

        function floorInQueue(elevator, floorNum) {
            return elevator.destinationQueue.indexOf(floorNum) != -1;
        }

        function floorButtonPressed(elevator, floorNum) {
            return elevator.getPressedFloors().indexOf(floorNum) != -1;
        }

        function removeFloorFromAllQueues(floorNum) {
            elevators.forEach(function(elev){
                if(!floorButtonPressed(elev, floorNum))
                {
                    elev.destinationQueue = elev.destinationQueue.filter(function(destination){
                        return destination != floorNum;
                    });
                    elev.checkDestinationQueue();
                    
                    if (elev.destinationQueue.length == 0)
                    {
                        elev.stop();
                        elev.goToFloor(0);
                    }
                }
            });
        }

        function inOtherQueue(elevator, floorNum) {
            elevators.forEach(function(elev){
                if(elev != elevator) {
                    var inQueue = elev.destinationQueue.indexOf(floorNum) != -1;
                    if(inQueue) {
                        return true;
                    }
                }
            })
            return false;
        }

        function isAvailableToSwap(elevator, floorNum) {
            elevators.forEach(function(elev){
                if(elev != elevator) {
                    var inQueue = elev.getPressedFloors().indexOf(floorNum) != -1;
                    if(inQueue) {

                        return false;
                    }
                }
            })
            return true;
        }

        function personWaiting(floorNum) {
            for(var i = 0; i < elevators.length; i++)
            {
                if(floorInQueue(elevators[i], floorNum) && !floorButtonPressed(elevators[i], floorNum))
                    return true;
            }
            return false;
        }

        //Calls the most appropriate elevator to the given floor
        function call_elevator(floorNum) {

            var bestElevator = elevators[0];
            var minDistance = floors.length;
            var distanceMatchCount = 0;
            
            for(var i = 0; i < elevators.length; i++)
            {
                var distance = Math.abs(elevators[i].currentFloor() - floorNum);
                if (distance <= minDistance){
                    if(distance == minDistance)
                        distance += 1;
                    
                    minDistance = distance;
                    bestElevator = elevators[i];
                }
            }
            
            var minWeight = 2;
            if (distanceMatchCount > 1) {
                for(var j = 0; j < elevators.length; j++) {
                    var distance = Math.abs(elevators[i].currentFloor() - floorNum);
                    if (distance == minDistance && minWeight < elevators[i].loadFactor()){
                        minWeight = elevators[i].loadFactor();
                        bestElevator = elevators[i];
                    }
                }
            }

            return bestElevator;
        }

        elevators.forEach(function(elevator){

            elevator.on("idle", function() {
                if (elevator.getPressedFloors().length == 0)
                    elevator.goToFloor(0);

            });

            elevator.on("floor_button_pressed", function(floorNum) { 
                elevator.goToFloor(floorNum);
            });

            elevator.on("passing_floor", function(floorNum, direction) { 

                if(personWaiting(floorNum) && elevator.loadFactor() < WEIGHT_FILTER){
                    removeFloorFromAllQueues(floorNum);
                    elevator.goToFloor(floorNum, true);
                }

            });

            elevator.on("stopped_at_floor", function(floorNum) {

                if (elevator.getPressedFloors().length > 0) {
                    var closest = 1000;
                    for(var i = 0; i < elevator.getPressedFloors().length; i++) {
                        if (elevator.getPressedFloors()[i] < closest) {
                            closest = elevator.getPressedFloors()[i];
                        }
                    }

                    elevator.destinationQueue = elevator.destinationQueue.filter(function(destination){
                        return destination != closest;
                    });
                    elevator.checkDestinationQueue();
                    elevator.goToFloor(closest, true);
                }
                console.log("FLOORS PRESSED: " + elevator.getPressedFloors());
                //console.log("Queue 0: " + elevators[0].destinationQueue + " <---> Queue 1: " + elevators[1].destinationQueue);
            })                                    
        });



        floors.forEach(function(floor){

            floor.on("up_button_pressed down_button_pressed", function() {
                var bestElevator = call_elevator(floor.floorNum());

                if (!floorInQueue(bestElevator, floor.floorNum()))
                    bestElevator.goToFloor(floor.floorNum());

                console.log("FLOORS PRESSED: " + bestElevator.getPressedFloors());
            })

        });

    },
        update: function(dt, elevators, floors) {
            // We normally don't need to do anything here
        }
}