import React from "react";
import { useState } from "react";
import {useEffect} from "react";

class figure{
    name;
    color;
    pos;
    available_moves;

    constructor(n, c, p, a){
        this.name = n;
        this.color = c;
        this.pos = p;
        this.available_moves = a;
    }
}


var figures = [new figure("pawn", "black", [1,1], [[1,3], [1,5]]), 
new figure("pawn", "white", [1,2], [[2,2], [2,5]]), new figure("knight", "black", [2,3], [[2,4], [4,5]])];
var selectedFigure = null;
var selectedPos = null;
var highlitedTiles = [[]];

function toArray(a){
    // console.log(a);
    var b = []
    for (var i = 0; i < a.length; i++){
        b.push([a[i].xPos, a[i].yPos])
        // console.log(a)
    }
    return b;
}

function StartGame(){
        const [Org, fetchOrg] = useState([])
        const getData = () => {
          fetch('http://localhost:5257/game')
            .then((res) => res.json())
            .then((res) => {
              fetchOrg(res)
            })
        }
      
        useEffect(() => {
          getData()
        }, [])
        if (Org.figures !== undefined){
            figures = [];
            Array(Org.figures)[0].forEach(x => figures.push(new figure(x.name, x.color, [x.xPos, x.yPos],toArray(x.availablePos))));
            return (figures);
            
        }
        return [];
    // return figures;
    }

function sendMove(pos, move){
    console.log(move);
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            posX: pos[0],
            posY: pos[1],
            moveX: move[0],
            moveY: move[1]
        })
    };
    const getData = () => {
        fetch('http://localhost:5257/game/move', requestOptions)
            .then(response => response.json())
    }
    console.log(getData());
    return true;
}



function highlight(moves){
    highlitedTiles = moves;
    const blackTiles = Array.from(document.getElementsByClassName("chess-tile black"));
    const whiteTiles = Array.from(document.getElementsByClassName("chess-tile white"));
    var tiles = [];
    moves.forEach(element => {
        if(blackTiles.find(x => x.id[0] === element[0].toString() && x.id[2] === element[1].toString()) !== undefined)
        tiles.push(blackTiles.find(x => x.id[0] === element[0].toString() && x.id[2] === element[1].toString()))  
    });
    moves.forEach(element => {
        if(whiteTiles.find(x => x.id[0] === element[0].toString() && x.id[2] === element[1].toString()) !== undefined){
            tiles.push(whiteTiles.find(x => x.id[0] === element[0].toString() && x.id[2] === element[1].toString()))
        }
    });
    tiles.forEach(x => x.style.backgroundColor = "blue");
}
    function unhighlight(moves){
        highlitedTiles = [[]];
        const blackTiles = Array.from(document.getElementsByClassName("chess-tile black"));
        const whiteTiles = Array.from(document.getElementsByClassName("chess-tile white"));
        var Wtiles = [];
        var Btiles = [];
        moves.forEach(element => {
            if(blackTiles.find(x => x.id[0] === element[0].toString() && x.id[2] === element[1].toString()) !== undefined)
            Btiles.push(blackTiles.find(x => x.id[0] === element[0].toString() && x.id[2] === element[1].toString()))  
        });
        moves.forEach(element => {
            if(whiteTiles.find(x => x.id[0] === element[0].toString() && x.id[2] === element[1].toString()) !== undefined){
                Wtiles.push(whiteTiles.find(x => x.id[0] === element[0].toString() && x.id[2] === element[1].toString()))
            }
        });
        Btiles.forEach(x => x.style.backgroundColor = "#008000");
        Wtiles.forEach(x => x.style.backgroundColor = "white");
    }

function ChessTile(color){
    const handleClick = (event) => {
        event.stopPropagation();
        if(highlitedTiles.find(x => x[0] === Number(event.target.id[0]) && x[1] === Number(event.target.id[2])) !== undefined){
            const f = figures.find(x => x.pos === selectedPos);
            const anwser = sendMove(selectedPos, [Number(event.target.id[0]), Number(event.target.id[2])]);
            if(anwser === true){
                if(f !== undefined)     
                { 
                     unhighlight(f.available_moves);
                     selectedPos = null;
                     figures = [];
                }
                 
            }
        }
    }
    if(color.color === "black")
        return (<div onClick={handleClick}  id={color.pos} className="chess-tile black"><Figure props={color.pos} /> </div>);
    return (<div onClick={handleClick} id= {color.pos} className="chess-tile white"><Figure props={color.pos}/> </div>)
}

function Figure(props){
    const pos = figures.find(x => x.pos[0] === Number(props.props[0]) && x.pos[1] === props.props[1]);
    if (pos !== undefined)
    switch(pos.name){
        case "pawn":
            return (
                    <button className={"button "} onClick={(event) => event.stopPropagation()}>
                        <Pawn props={pos}/>
                    </button>
            );
        case "knight":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Knight props={pos}/>
                </ button>
            );
        case "rook":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Rook props={pos}/>
                </button>
            );
        case "bishop":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Bishop props={pos}/>
                </button>
            );
        case "queen":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Queen props={pos}/>
                </button>
            );
        case "king":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <King props={pos}/>
                </button>
            );
        default:
            return null;
    }
    return null;
}

function Pawn(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return(
        <div className={"figure " +  props.props.color+ "-pawn"} onClick={(event) => handleClick(event, props.props.pos)}>
        </div>
    )
}

function Knight(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return (<div className={"figure " +  props.props.color+ "-knight"  } onClick={(event) => handleClick(event, props.props.pos)}></div>)
}

function Rook(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return (<div className={"figure " +  props.props.color+ "-rook"} onClick={(event) => handleClick(event, props.props.pos)} ></div>)
}

function Queen(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return (<div className={"figure " +  props.props.color+ "-queen"} onClick={(event) => handleClick(event, props.props.pos)} ></div>)
}

function King(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return (<div className={"figure " +  props.props.color+ "-king"} onClick={(event) => handleClick(event, props.props.pos)} ></div>)
}
function Bishop(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return (<div className={"figure " +  props.props.color+ "-bishop"} onClick={(event) => handleClick(event, props.props.pos)}></div>)
}

function ChessRow(props){
    if(props.props % 2)
    return(
        <div>
            <ChessTile color="white" pos={[props.props,0]}/>
            <ChessTile color="black" pos={[props.props,1]}/>
            <ChessTile color="white" pos={[props.props,2]}/>
            <ChessTile color="black" pos={[props.props,3]}/>
            <ChessTile color="white" pos={[props.props,4]}/>
            <ChessTile color="black" pos={[props.props,5]}/>
            <ChessTile color="white" pos={[props.props,6]}/>
            <ChessTile color="black" pos={[props.props,7]}/>
        </div>
    );

    return(
        <div>
            <ChessTile color="black" pos={[props.props,0]}/>
            <ChessTile color="white" pos={[props.props,1]}/>
            <ChessTile color="black" pos={[props.props,2]}/>
            <ChessTile color="white" pos={[props.props,3]}/>
            <ChessTile color="black" pos={[props.props,4]}/>
            <ChessTile color="white" pos={[props.props,5]}/>
            <ChessTile color="black" pos={[props.props,6]}/>
            <ChessTile color="white" pos={[props.props,7]}/>
        </div>
    );
}

function Chessboard(){
    const [move, setMove] = useState([]);
    const res = StartGame();
    const handleClick = () => {
       setMove(res);
    }

   return (
        <div>
            <ChessRow className="board-row" props="0" />
            <ChessRow className="board-row" props="1" />
            <ChessRow className="board-row" props="2" />
            <ChessRow className="board-row" props="3" />
            <ChessRow className="board-row" props="4" />
            <ChessRow className="board-row" props="5" />
            <ChessRow className="board-row" props="6" />
            <ChessRow className="board-row" props="7" />
            <button onClick={handleClick}></button>
        </div>
    );
}


function Game() {
        return (
            <div className="game">
                <div className="game-board">
                    <Chessboard />
                </div>
            </div>
        );
}

export default Game;