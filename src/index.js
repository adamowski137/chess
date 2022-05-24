import React, { Component } from "react";
import ReactDOM from "react-dom";
import Chessboard from "./chessboard";
import './index.css';


ReactDOM.render(
    <div className="game">
    <div className="game-board">
        <Chessboard />
    </div>
    </div>,
    document.getElementById('root')
);