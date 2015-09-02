{
    init: function(elevators, floors) {

        function isInQueue(queue, value) {
            console.log("RESULTS: " + queue);
            return queue.indexOf(value) != -1;
        }

        var elevator = elevators[0]; // Let's use the first elevator
        var load_value = 0.666;

        // Whenever the elevator is idle (has no more queued destinations) ...
        elevator.on("idle", function() {
            // let's go to all the floors (or did we forget one?)

            if (!isInQueue(elevator.destinationQueue, 0)) {
                elevator.goToFloor(0);
            }
        });

        elevator.on("floor_button_pressed", function(floorNum) {
            if (!isInQueue(elevator.destinationQueue, floorNum)) {
                elevator.goToFloor(floorNum);
            }
        });

        elevator.on("passing_floor", function(floorNum, direction) { 

            if(elevator.getPressedFloors().length > 0 && elevator.loadFactor() < load_value && !isInQueue(elevator.destinationQueue, floorNum)) {

                elevator.getPressedFloors().forEach(function(floor){
                    if (floor == floorNum){ 
                        elevator.destinationQueue = elevator.destinationQueue.filter(function(destination){
                            return destination != floorNum;
                        });

                        elevator.checkDestinationQueue();
                        elevator.goToFloor(floorNum, true);
                    }
                });

            }
            else if(elevator.destinationQueue.indexOf(elevator.currentFloor()) != -1) {
                elevator.destinationQueue = elevator.destinationQueue.filter(function(destination){
                    return destination != floorNum;
                });

                elevator.checkDestinationQueue();
                elevator.goToFloor(floorNum, true);
            }

        });


        floors.forEach(function(floor){

            floor.on("up_button_pressed down_button_pressed", function() {
                if (!isInQueue(elevator.destinationQueue, floor.floorNum())) {
                    elevator.goToFloor(floor.floorNum());
                }
            });

        });


    },
        update: function(dt, elevators, floors) {
            // We normally don't need to do anything here
        }
}