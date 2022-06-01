import Chessboard from "./game/chessboard";
import ValueCounter from "./panel/valueCounter";
import { useState } from "react";
import {useEffect} from "react";

function Game(){
    const [figures, setFigures]= useState([]);
    const [selectedFigure, setSelected] = useState([]);
    const [highlightedTiles, setHighlighted] = useState([]);
    const [fig, fetchFig] = useState([]);
    const [checkPosition, setChecked] = useState([]);

    const setChessboard = async () => {
        await getData();
        if(fig !== undefined)
        setFigures(fig.figures);
        if(fig.additional !== null){
            setChecked(fig.additional.isCheck);
        }
        else setChecked([]);
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
                if(res.additional !== null)
                {
                    setChecked(res.additional.isCheck);
                    console.log(res.additional.isCheck);
                }
                else setChecked([]);
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
    return(
    <div className="game">
        <div className="game-panel">
            <div className="game-board">
                <Chessboard figures={figures} selectFigure={selectFigure} selectedFigure={selectedFigure} highlightTiles={highlightTiles} highlightedTiles={highlightedTiles} sendMove={sendMove} setChessboard={setChessboard} checkPosition={checkPosition}/>
            </div>
        </div>
        <div className="panel">
            <button onClick={setChessboard} className="start"> Rozpocznij </button>
            <ValueCounter value={1}/>
        </div>
    </div>
    );
}

export default Game;