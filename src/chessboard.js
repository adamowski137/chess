import ChessRow from "./chessRow";
import { useState } from "react";
import {useEffect} from "react";

function Chessboard(){
    const [figures, setFigures]= useState([]);
    const [selectedFigure, setSelected] = useState([]);
    const [highlightedTiles, setHighlighted] = useState([]);
    const [fig, fetchFig] = useState([])
    const setChessboard = async () => {
        await getData();
        if(fig !== undefined)
        setFigures(fig.figures);
        setSelected([]);
        setHighlighted([]);

    }

    const getData = async () => {
        await fetch('http://localhost:5257/game')
        .then((res) => res.json())
        .then((res) => {
            fetchFig(res)
        })
    }
    useEffect(() => {
        getData()
        setChessboard();
    },[])

    const sendMove =  (pos, move) => {
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
             fetch('http://localhost:5257/game/move', requestOptions)
            .then((res) => res.json())
            .then((res) => {
                if(res !== undefined)
                setFigures(res.figures);
                setSelected([]);
                setHighlighted([]);
            })
    }


    const selectFigure = (childData) => {
        setSelected(childData);
    }
    const highlightTiles = (childData) => {
        setHighlighted(childData);
    }




    return (
        <div onClick={(event) => {event.stopPropagation()}}>
            <ChessRow className="board-row" figures = {figures} row = {0} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard}/>          
            <ChessRow className="board-row" figures = {figures} row = {1} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard}/>          
            <ChessRow className="board-row" figures = {figures} row = {2} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard}/>          
            <ChessRow className="board-row" figures = {figures} row = {3} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard}/>          
            <ChessRow className="board-row" figures = {figures} row = {4} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard}/>          
            <ChessRow className="board-row" figures = {figures} row = {5} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard}/>          
            <ChessRow className="board-row" figures = {figures} row = {6} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard}/>          
            <ChessRow className="board-row" figures = {figures} row = {7} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard}/> 
            <button onClick={setChessboard}> START </button>
        </div>
    );

}




    

export default Chessboard;