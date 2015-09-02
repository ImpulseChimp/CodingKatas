{
    init: function(elevators, floors) {

        function isInQueue(queue, value) {
            queue.forEach(function(destination){
                if (value == destination)
                {
                    return true;
                }

                console.log("VALUES: " + value + " " + destination);
                console.log();

            });
            return false;
        }

        var elevator = elevators[0]; // Let's use the first elevator
        var load_value = 0.666;

        // Whenever the elevator is idle (has no more queued destinations) ...
        elevator.on("idle", function() {
            // let's go to all the floors (or did we forget one?)

            if (!isInQueue(elevator.destinationQueue, 0)) {
                elevator.goToFloor(0);
                console.log(elevator.destinationQueue);
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
                console.log("Pressed: " + floor.floorNum());
                console.log("In queue (" + floor.floorNum() + "): " + !isInQueue(elevator.destinationQueue, floor.floorNum()))
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