var roundCount = 0;
var currentAliveCells = 0;
var birthedCells = 0;
var killedCells = 0;

var blocksCreated = false;
var boardGenerated = false;


var blockWidth = 0;
var blockHeight = 0;
var loopWaitTime = 500;
var boardRunning = false;
var lifeStepInterval;
var largestIndex = 0;

function generateGridBlocks(xGridCount, yGridCount) {
    var board = $("#game-of-life-board");
    
    var blockHTML = '<div class="block"></div>';
    var boardHTML = "";
    
    blockWidth = board.width() / xGridCount;
    blockHeight = board.height() / yGridCount;
    
    var row = 0;
    var column = 0;

    for(var i = 0; i < xGridCount * yGridCount; i++) {
        
        if((i % xGridCount) == 0) {
            if(column != 0)
                row++;
            column = 0;
        }

        boardHTML += '<div id="' + row + "-" + column + '" class="block"></div>';

        column++;
    }
    
    board.html(boardHTML);
}

function styleBoard() {
    $(".block").width(blockWidth);
    $(".block").height(blockHeight);
}

$("#generate-board").on("click", function() {
    styleBoard();
    
    $(".block").on("click", function(){
        if(!boardRunning) {
            if($(this).hasClass("selected")) {
                $(this).removeClass("selected");
                decrementCurrentAliveCounter();
            }
            else {
                $(this).addClass("selected");
                incrementCurrentAliveCounter();
            }
        }
    });

    $("#game-of-life-board").css("background-color", "white");
    boardGenerated = true;
})

$("#start-button").on("click" , function() {
    if(!boardRunning && boardGenerated) {
        boardRunning = true;
        lifeStepInterval = setInterval(simulateLifeStep, loopWaitTime);
    }
})

$("#step-button").on("click" , function() {
    if(!boardRunning && boardGenerated) {
        simulateLifeStep();
    }
})

$("#stop-button").on("click" , function() {
    if(boardRunning && boardGenerated) {
        boardRunning = false;
        clearInterval(lifeStepInterval);
    }
})

$("#reset-button").on("click" , function() {
    $("#game-of-life-board").html("");
    $("#grid-selector").val("default");
    $("#round-counter").html(0);
    roundCount = 0;
    currentAliveCells = 0;
    birthedCells = 0;
    killedCells = 0;

    $("#round-counter").html(0);
    $("#current-alive-cell-counter").html(0);
    $("#birthed-cell-counter").html(0);
    $("#killed-cell-counter").html(0);

    blocksCreated = false;
    boardGenerated = false;
})

$("#grid-selector").change(function() {
    $("#game-of-life-board").html("");
    var pars = $("#grid-selector").val().split("x");
    largestIndex = parseInt(pars[1]) - 1;
    generateGridBlocks(parseInt(pars[0]), parseInt(pars[1]));
    blocksCreated = true;
});

function simulateLifeStep() {

    var splitBlockId;

    $(".block").each(function(){
        var liveNeighborCount = getLiveNeighborCount($(this));

        if($(this).hasClass("selected")) {
            if(liveNeighborCount < 2 || liveNeighborCount > 3) {
                $(this).removeClass("selected");
                decrementCurrentAliveCounter()
                incrementKilledCounter();
            }
        }
        else {
            if(liveNeighborCount == 3) {
                $(this).addClass("selected");
                incrementCurrentAliveCounter();
                incrementBirthedCounter();
            }
        }
    });

    incrementRoundCounter();
}

function getLiveNeighborCount(block) {
    var explodedId = block.attr("id").split("-");
    var splitId = [parseInt(explodedId[0]), parseInt(explodedId[1])];
    var aliveNeighbors = 0;

    var leftColumnExists = false;
    var rightColumnExists = false;
    var aboveRowExists = false;
    var belowRowExists = false;

    //Check if column to left exists
    if((splitId[1] - 1) >= 0)
        leftColumnExists = true;

    //Check if column to right exists
    if((splitId[1] + 1) <= largestIndex)
        rightColumnExists = true;

    //Check if above row exists
    if((splitId[0] - 1) >= 0)
        aboveRowExists = true;

    //Check if below row exists
    if((splitId[0] + 1) <= largestIndex)
        belowRowExists = true;

    if(aboveRowExists){
        if(leftColumnExists && $("#" + (splitId[0] - 1) + "-" + (splitId[1] - 1)).hasClass("selected"))
            aliveNeighbors++;

        if($("#" + (splitId[0] - 1) + "-" + (splitId[1])).hasClass("selected"))
            aliveNeighbors++;

        if(rightColumnExists && $("#" + (splitId[0] - 1) + "-" + (splitId[1] + 1)).hasClass("selected"))
            aliveNeighbors++;
    }

    if(belowRowExists){
        if(leftColumnExists && $("#" + (splitId[0] + 1) + "-" + (splitId[1] - 1)).hasClass("selected"))
            aliveNeighbors++;

        if($("#" + (splitId[0] + 1) + "-" + (splitId[1])).hasClass("selected"))
            aliveNeighbors++;

        if(rightColumnExists && $("#" + (splitId[0] + 1) + "-" + (splitId[1] + 1)).hasClass("selected"))
            aliveNeighbors++;
    }
      
    if(leftColumnExists && $("#" + (splitId[0]) + "-" + (splitId[1] - 1)).hasClass("selected"))
        aliveNeighbors++;

    if(rightColumnExists && $("#" + (splitId[0]) + "-" + (splitId[1] + 1)).hasClass("selected"))
        aliveNeighbors++;

    return aliveNeighbors;
}

function incrementRoundCounter() {
    $("#round-counter").html(++roundCount);
}

function incrementCurrentAliveCounter() {
    $("#current-alive-cell-counter").html(++currentAliveCells);
}

function decrementCurrentAliveCounter() {
    $("#current-alive-cell-counter").html(--currentAliveCells);
}

function incrementBirthedCounter() {
    $("#birthed-cell-counter").html(++birthedCells);
}

function incrementKilledCounter() {
    $("#killed-cell-counter").html(++killedCells);
}