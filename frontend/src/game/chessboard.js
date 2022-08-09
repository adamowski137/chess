import ChessRow from "./chessRow";


function Chessboard({figures, selectFigure, selectedFigure, highlightTiles, highlightedTiles, sendMove, setChessboard, checkPosition}){
   




    return (
        <div onClick={(event) => {event.stopPropagation()}}>
            <ChessRow className="board-row" figures = {figures} row = {0} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard} isChecked={checkPosition}/>          
            <ChessRow className="board-row" figures = {figures} row = {1} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard} isChecked={checkPosition}/>          
            <ChessRow className="board-row" figures = {figures} row = {2} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard} isChecked={checkPosition}/>          
            <ChessRow className="board-row" figures = {figures} row = {3} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard} isChecked={checkPosition}/>          
            <ChessRow className="board-row" figures = {figures} row = {4} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard} isChecked={checkPosition}/>          
            <ChessRow className="board-row" figures = {figures} row = {5} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard} isChecked={checkPosition}/>          
            <ChessRow className="board-row" figures = {figures} row = {6} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard} isChecked={checkPosition}/>
            <ChessRow className="board-row" figures = {figures} row = {7} setSelected={selectFigure} selected={selectedFigure} highlightTiles={highlightTiles} highlighted={highlightedTiles} sendMove={sendMove} getChessboard={setChessboard} isChecked={checkPosition}/> 
        </div>
    );

}   

export default Chessboard;