import Chessboard from "./game/chessboard";
import ValueCounter from "./panel/valueCounter";
import PromotePanel from "./game/popup";
import { useState } from "react";
import {useEffect} from "react";
import Popup from "./game/popup";

function Game(){
    const [figures, setFigures]= useState([]);
    const [selectedFigure, setSelected] = useState([]);
    const [highlightedTiles, setHighlighted] = useState([]);
    const [fig, fetchFig] = useState([]);
    const [checkPosition, setChecked] = useState([]);
    const [currentMove, setMove] = useState([]);
    const [chessValue, setValue] = useState(0);
    const [popup, setPopup] = useState(false);
    const [isMate, setMate] = useState(false);
    const setChessboard = async () => {
        await getData();
        if(fig !== undefined && fig.figures !== undefined)
        setFigures(fig.figures);
        setChecked([]);
        setSelected([]);
        setHighlighted([]);
        setValue(0);

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
        setMove(move)
        const s = figures.find(x => x.xPos === pos[0] && x.yPos === pos[1]);
        if (s !== undefined && s.name === "pawn" && s.color === "black" && move[0] === 0)  {setPopup(true);  return;}
        if (s !== undefined && s.name === "pawn" && s.color === "white" && move[0] === 7)  {setPopup(true);  return;}
        
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                posX: pos[0],
                posY: pos[1],
                moveX: move[0],
                moveY: move[1],
            })
        };
        if(popup){
           console.log("xd");
           return; 
        }
        fetch('http://localhost:5257/game/move', requestOptions)
            .then((res) => res.json())
            .then((res) => {
                if(res !== undefined && res.figures !== undefined)
                setFigures(res.figures);
                if(res.additional !== null)
                {
                    document.getElementById("bar").style.height = (50 + 5*res.additional.value).toString() + "%";
                    setValue(res.additional.value);
                    if(res.additional.isCheck !== null)
                    setChecked(res.additional.isCheck);
                    else setChecked([]);
                    setMate(res.additional.isMate);
                }
                setSelected([]);
                setHighlighted([]);
            })
    }
    function GameOver({isMate}){
        console.log(isMate);
        if(isMate === false || isMate === undefined || isMate === null) return [];
        else return(
        <div className="game-over" >
            GG
        </div>
            )
    }
    const selectFigure = (childData) => {
        setSelected(childData);
    }
    const highlightTiles = (childData) => {
        setHighlighted(childData);
    }
    //popup control
    const handleQueen = () => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                posX: selectedFigure[0],
                posY: selectedFigure[1],
                moveX: currentMove[0],
                moveY: currentMove[1],
                promote: "queen"
            })
        };
        fetch('http://localhost:5257/game/promote', requestOptions)
            .then((res) => res.json())
            .then((res) => {
                if(res !== undefined && res.figures !== undefined)
                setFigures(res.figures);
                if(res.additional !== null)
                {
                    // console.log((50 + 10*res.additional.value).toString() + "%")
                    document.getElementById("bar").style.height = (50 + 5*res.additional.value).toString() + "%";
                    setValue(res.additional.value);
                    if(res.additional.isCheck !== null)
                    setChecked(res.additional.isCheck);
                    else setChecked([]);
                    setMate(res.additional.isMate);
                }
                setPopup(false);
                setSelected([]);
                setHighlighted([]);
            })
    }
    const handleBishop = () => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                posX: selectedFigure[0],
                posY: selectedFigure[1],
                moveX: currentMove[0],
                moveY: currentMove[1],
                promote: "bishop"
            })
        };
        fetch('http://localhost:5257/game/promote', requestOptions)
            .then((res) => res.json())
            .then((res) => {
                if(res !== undefined && res.figures !== undefined)
                setFigures(res.figures);
                if(res.additional !== null)
                {
                    // console.log((50 + 10*res.additional.value).toString() + "%")
                    document.getElementById("bar").style.height = (50 + 5*res.additional.value).toString() + "%";
                    setValue(res.additional.value);
                    if(res.additional.isCheck !== null)
                    setChecked(res.additional.isCheck);
                    else setChecked([]);
                    setMate(res.additional.isMate);
                }
                setPopup(false);
                setSelected([]);
                setHighlighted([]);
            })
    }
    const handleRook = () => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                posX: selectedFigure[0],
                posY: selectedFigure[1],
                moveX: currentMove[0],
                moveY: currentMove[1],
                promote: "rook"
            })
        };
        fetch('http://localhost:5257/game/promote', requestOptions)
            .then((res) => res.json())
            .then((res) => {
                if(res !== undefined && res.figures !== undefined)
                setFigures(res.figures);
                if(res.additional !== null)
                {
                    // console.log((50 + 10*res.additional.value).toString() + "%")
                    document.getElementById("bar").style.height = (50 + 5*res.additional.value).toString() + "%";
                    setValue(res.additional.value);
                    if(res.additional.isCheck !== null)
                    setChecked(res.additional.isCheck);
                    else setChecked([]);
                }
                setPopup(false);
                setSelected([]);
                setHighlighted([]);
            })
    }
    const handleKnight = () => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                posX: selectedFigure[0],
                posY: selectedFigure[1],
                moveX: currentMove[0],
                moveY: currentMove[1],
                promote: "knight"
            })
        };
        fetch('http://localhost:5257/game/promote', requestOptions)
            .then((res) => res.json())
            .then((res) => {
                if(res !== undefined && res.figures !== undefined)
                setFigures(res.figures);
                if(res.additional !== null)
                {
                    // console.log((50 + 10*res.additional.value).toString() + "%")
                    document.getElementById("bar").style.height = (50 + 5*res.additional.value).toString() + "%";
                    setValue(res.additional.value);
                    if(res.additional.isCheck !== null)
                    setChecked(res.additional.isCheck);
                    else setChecked([]);
                    setMate(res.additional.isMate);
                }
                setPopup(false);
                setSelected([]);
                setHighlighted([]);
            })
    }


    return(
    <div className="game">
        <div className="game-panel">
            <GameOver isMate={isMate}/>
            <div className="game-board">
                <Chessboard figures={figures} selectFigure={selectFigure} selectedFigure={selectedFigure} highlightTiles={highlightTiles} highlightedTiles={highlightedTiles} sendMove={sendMove} setChessboard={setChessboard} checkPosition={checkPosition}/>
                <Popup set={popup} handleQueen={handleQueen} handleBishop={handleBishop} handleKnight={handleKnight} handleRook={handleRook} />
            </div>
        </div>
        <div className="panel">
            <button onClick={setChessboard} className="start"> Rozpocznij </button>
            <ValueCounter value={chessValue}/>
        </div>
    </div>
    );
}

export default Game;