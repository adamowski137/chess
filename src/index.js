import React, { Component } from "react";
import ReactDOM from "react-dom";
import Game  from "./app";
import './index.css';

// class figure{
//     posX;
//     posY;
//     name;
//     color;
//     listOfMoves;
//     constructor(x, y, name, color, moves){
//         this.posX = x;
//         this.posY = y;
//         this.name = name;
//         this.color = color;
//         this.listOfMoves = moves;
//     }
// }

// class Figure extends React.Component{
//     state = {
//         blackFigures: []
//     }
//     componentDidMount() {
//         axios.get('https://localhost:44384/game/start')
//             .then(res => {
//                 const figures = res.data;
//                 console.log(figures);
//                 this.setState({figures});
//             })
//     }
//     render(){
//         return(
//             <div>
//             {
//                 console.log(this.state.blackFigures)
//             }
//             </div>
//         )
//     }

// }

// class move{
//     posX;
//     posY;
// }
// // const positions = [[1,0,"Pawn","black"],[1,1,"Pawn","black"], [1,2,"Pawn","black"], [1,3,"Pawn","black"],[1,4,"Pawn","black"],
// // [1,5,"Pawn","black"], [1,6, "Pawn","black"], [1,7, "Pawn","black"],[0,1,"Knight","black"], [0,6, "Knight","black"], [0,0,"Rook","black"],
// // [0,7,"Rook","black"], [0,2,"Bishop","black"], [0,5,"Bishop","black"], [0,4,"King","black"], [0,3,"Queen","black"],
// // [6,0,"Pawn","white"],[6,1,"Pawn","white"], [6,2,"Pawn","white"], [6,3,"Pawn","white"],[6,4,"Pawn","white"],
// // [6,5,"Pawn","white"], [6,6, "Pawn","white"], [6,7, "Pawn","white"],[7,1,"Knight","white"], [7,6, "Knight","white"], [7,0,"Rook","white"],
// // [7,7,"Rook","white"], [7,2,"Bishop","white"], [7,5,"Bishop","white"], [7,4,"King","white"], [7,3,"Queen","white"]];
// var positions = [new figure(1,0,"Pawn","black",[3,3]), new figure(1, 1, "Pawn", "black",null), new figure(3,3,"Knight","black", null)];
// class BlackPawn extends React.Component{
//     render(){
//         return (<button className="figure black-pawn" id="120"></button>)
//     }
// }
// class WhitePawn extends React.Component{
//     render(){
//         return (<button className="figure white-pawn"></button>)
//     }
// }
// class WhiteKnight extends React.Component{
//     render(){
//         return (<button className="figure white-knight"></button>);
//     }
// }
// class BlackKnight extends React.Component{
//     render(){
//         return (<button className="figure black-knight"></button>);
//     }
// }
// class BlackRook extends React.Component{
//     render(){
//         return (<button className="figure black-rook"></button>);
//     }
// }
// class WhiteRook extends React.Component{
//     render(){
//         return (<button className="figure white-rook"></button>);
//     }
// }
// class BlackBishop extends React.Component{
//     render(){
//         return (<button className="figure black-bishop"></button>)
//     }
// }
// class WhiteBishop extends React.Component{
//     render(){
//         return (<button className="figure white-bishop"></button>)
//     }
// }
// class BlackKing extends React.Component{
//     render(){
//         return (<button className="figure black-king"></button>)
//     }
// }
// class WhiteKing extends React.Component{
//     render(){
//         return (<button className="figure white-king"></button>)
//     }
// }
// class WhiteQueen extends React.Component{
//     render(){
//         return (<button className="figure white-queen"></button>)
//     }
// }
// class BlackQueen extends React.Component{
//     render(){
//         return (<button className="figure black-queen"></button>)
//     }
// }
// class Chessboard extends React.Component{
//     renderChessTile(i, j, color){
//         const pos = positions.find(x => (x.posX === i) && x.posY === j);
//         if(pos !== undefined)
//         return(
//             <div className={"chess-tile "+color} id={(i*10+j).toString()}>
//                 {this.setFigure(pos.name,pos.color)}
//             </div> );
//         return(
//             <div className={"chess-tile "+color} id={(i*10+j).toString()}>
//             </div>);
//     }
//     setPosition(i,j){
//         var a = document.getElementsByClassName("pawn").array;
//         console.log(a);
//     }

//     setFigure(name, color){
//         if  (name === "Pawn" && color === "black")    return(<BlackPawn/>);
//         if  (name === "Knight" && color === "black")  return(<BlackKnight/>);
//         if  (name === "Rook" && color === "black")    return(<BlackRook/>)
//         if  (name === "Bishop" && color === "black")  return(<BlackBishop/>);
//         if  (name === "King" && color === "black")    return(<BlackKing/>);
//         if  (name === "Queen" && color === "black")   return(<BlackQueen/>)

//         if  (name === "Pawn" && color === "white")    return(<WhitePawn/>);
//         if  (name === "Knight" && color === "white")  return(<WhiteKnight/>);
//         if  (name === "Rook" && color === "white")    return(<WhiteRook/>)
//         if  (name === "Bishop" && color === "white")  return(<WhiteBishop/>);
//         if  (name === "King" && color === "white")    return(<WhiteKing/>);
//         if  (name === "Queen" && color ===   "white")   return(<WhiteQueen/>)
//     }

//     renderChessRow(i){
//         if(i%2)
//             return(
//             <div>
//                 {this.renderChessTile(i, 0, "white")}
//                 {this.renderChessTile(i, 1, "black")}
//                 {this.renderChessTile(i, 2, "white")}
//                 {this.renderChessTile(i, 3, "black")}
//                 {this.renderChessTile(i, 4, "white")}
//                 {this.renderChessTile(i, 5, "black")}
//                 {this.renderChessTile(i, 6, "white")}
//                 {this.renderChessTile(i, 7, "black")}
//             </div>
//             );
//         return(
//         <div>
//             {this.renderChessTile(i, 0, "black")}
//             {this.renderChessTile(i, 1, "white")}
//             {this.renderChessTile(i, 2, "black")}
//             {this.renderChessTile(i, 3, "white")}
//             {this.renderChessTile(i, 4, "black")}
//             {this.renderChessTile(i, 5, "white")}
//             {this.renderChessTile(i, 6, "black")}
//             {this.renderChessTile(i, 7, "white")}
//         </div>
//         );
//     }

//     render (){
//         return(
//             <div>
//                 <div className="board-row">
//                     {this.renderChessRow(0)}
//                 </div>
//                 <div className="board-row">
//                     {this.renderChessRow(1)}
//                 </div>
//                 <div className="board-row">
//                     {this.renderChessRow(2)}
//                 </div>
//                 <div className="board-row">
//                     {this.renderChessRow(3)}
//                 </div>
//                 <div className="board-row">
//                     {this.renderChessRow(4)}
//                 </div>
//                 <div className="board-row">
//                     {this.renderChessRow(5)}
//                 </div>
//                 <div className="board-row">
//                     {this.renderChessRow(6)}
//                 </div>
//                 <div className="board-row">
//                     {this.renderChessRow(7)}
//                 </div>
//             </div>
//         );
//     }
// }

// class Game extends React.Component {
//     render(){
//         return (
//             <div className="game">
//                 <div className="game-board">
//                     <Chessboard />
//                 </div>
//             </div>
//         );
//     }
// }

// function selectedFigure(id){
//     const tile = document.getElementById(id);
//     tile.style.backgroundColor = "red"
// }

// function showAvailableTiles(moves){
//     moves.forEach(element => document.getElementById((element[0]*10 +element[1]).toString()).style.backgroundColor = "black");
// }
// ReactDOM.render(
//     <Game />,
//     document.getElementById('root'),
//     );
// // selectedFigure("120");
// // showAvailableTiles([[0,0], [0,1]]);

ReactDOM.render(
    <Game />,
    document.getElementById('root')
);