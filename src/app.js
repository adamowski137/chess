import React from "react";
import { useState } from "react";

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

const figures = [new figure("pawn", "black", [1,1], [[1,3], [1,5]]), 
new figure("pawn", "white", [1,2], [[2,2], [2,5]]), new figure("knight", "black", [3,3], [[2,4], [4,5]])];
var selectedFigure = [-1, -1];

function setSelectedFigure(event){
    // console.log(selectedFigure);
    if(selectedFigure !== event.pos) selectedFigure = event.pos;
    else selectedFigure = [-1, -1];
    // event.style.backgroundColor="black";
}

function ChessTile(color){
    // console.log(selectedFigure);
    if(Number(color.pos[0]) === Number(selectedFigure[0]) && Number(color.pos[1]) === Number(selectedFigure[1]))
        return(<div className="chess-tile selected"> </div>)
    if(color.color === "black")
        return (<div className="chess-tile black"><Figure props={color.pos} /> </div>);
    return (<div className="chess-tile white"><Figure props={color.pos}/> </div>)
}

function Figure(props){
    // console.log(props.props);
    const [selected, setSelected] = useState(false);
    const pos = figures.find(x => x.pos[0] === Number(props.props[0]) && x.pos[1] === props.props[1]);
    const handleClick = (event) => {
        // console.log(event.target);
        if(selected === false)
            setSelected("selected");
        else setSelected(false);
    };
    if (pos !== undefined)
    switch(pos.name){
        case "pawn":
            return (
                    <button className={"button " + selected}  onClick={handleClick}>
                        <Pawn props={pos}/>
                    </button>
            );
        case "knight":
            return (
                <button className={"button " + selected}  onClick={handleClick}>
                <Knight props={pos}/>
                </ button>
            );
        case "rook":
            return (
                <button className={"button " + selected}  onClick={handleClick}>
                <Rook props={pos}/>
                </button>
            );
        case "bishop":
            return (
                <button className={"button " + selected}  onClick={handleClick}>
                <Bishop props={pos}/>
                </button>
            );
        case "queen":
            return (
                <button className={"button " + selected}  onClick={handleClick}>
                <Queen props={pos}/>
                </button>
            );
        case "king":
            return (
                <button className={"button " + selected}  onClick={handleClick}>
                <King props={pos}/>
                </button>
            );
        default:
            return null;
    }
    return null;
}

function Pawn(props) {
    return (<div className={"figure " +  props.props.color+ "-pawn "  } ></div>)
}

function Knight(props) {
    return (<div className={"figure " +  props.props.color+ "-knight"  } ></div>)
}

function Rook(props) {
    return (<div className={"figure " +  props.props.color+ "-rook"  } ></div>)
}

function Queen(props) {
    return (<div className={"figure " +  props.props.color+ "-queen"  } ></div>)
}

function King(props) {
    return (<div className={"figure " +  props.props.color+ "-king"  } ></div>)
}
function Bishop(props) {
    return (<div className={"figure " +  props.props.color+ "-bishop"  } ></div>)
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
    // console.log(props.props)
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