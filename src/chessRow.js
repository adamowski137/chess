import ChessTile from "./chessTile";
function ChessRow({figures, row, selected, setSelected, highlightTiles, highlighted, sendMove, getChessboard}){
    if(row % 2)
    return(
        <div>
            <ChessTile figures = {figures} position = {[row, 0]} color="white" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 1]} color="black" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 2]} color="white" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 3]} color="black" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 4]} color="white" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 5]} color="black" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 6]} color="white" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 7]} color="black" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
        </div>
    );

    return(
        <div>
            <ChessTile figures = {figures} position = {[row, 0]} color="black" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 1]} color="white" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 2]} color="black" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 3]} color="white" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 4]} color="black" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 5]} color="white" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 6]} color="black" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
            <ChessTile figures = {figures} position = {[row, 7]} color="white" setSelected={setSelected} selected={selected} highlightTiles={highlightTiles} highlighted={highlighted} sendMove={sendMove} getChessboard={getChessboard}/>
        </div>
    );
}

export default ChessRow;