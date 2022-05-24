import ChessRow from "./chessRow";
import { useState } from "react";
import {useEffect} from "react";

function StartGame(){
    // const [Org, fetchOrg] = useState([])
    // var figures;
    // const getData = () => {
    //   fetch('http://localhost:5257/game')
    //     .then((res) => res.json())
    //     .then((res) => {
    //       fetchOrg(res)
    //     })
    // }
  
    // useEffect(() => {
    //   getData()
    // }, [])
    // if (Org.figures !== undefined){
    //     figures = [];
    //     Array(Org.figures)[0].forEach(x => figures.push(new figure(x.name, x.color, [x.xPos, x.yPos],toArray(x.availablePos))));
    //     return (figures);
        
    // }
    // return figures;
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
    new figure("pawn", "white", [1,2], [[2,2], [2,5]]), new figure("knight", "black", [2,3], [[2,4], [4,5]])];
    
    return figures;
}
function Chessboard(){
    const figures = StartGame();
    const [selectedFigure, setSelected] = useState([]);
    const [highlightedTiles, setHighlighted] = useState([]);
    const selectFigure = (childData) => {
        setSelected(childData);
    }
    const highlightTiles = (childData) => {
        setHighlighted(childData);
    }

    return (        
        <div>
            <ChessRow className="board-row" figures = {figures} row = {0} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles}/>
            <ChessRow className="board-row" figures = {figures} row = {1} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles}/>
            <ChessRow className="board-row" figures = {figures} row = {2} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles}/>
            <ChessRow className="board-row" figures = {figures} row = {3} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles}/>
            <ChessRow className="board-row" figures = {figures} row = {4} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles}/>
            <ChessRow className="board-row" figures = {figures} row = {5} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles}/>
            <ChessRow className="board-row" figures = {figures} row = {6} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles}/>
            <ChessRow className="board-row" figures = {figures} row = {7} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles}/>
            <div>{selectedFigure}</div>
        </div>
    );

}

export default Chessboard;