import Figure from "./figure";
function ChessTile({figures, position, color, selected, setSelected, highlightTiles}){
    const handleClick = (event) => {
        // event.stopPropagation();
        // if(highlitedTiles.find(x => x[0] === Number(event.target.id[0]) && x[1] === Number(event.target.id[2])) !== undefined){
        //     const f = figures.find(x => x.pos === selectedPos);
        //     const anwser = sendMove(selectedPos, [Number(event.target.id[0]), Number(event.target.id[2])]);
        //     if(anwser === true){
        //         if(f !== undefined)     
        //         { 
        //              unhighlight(f.available_moves);
        //              selectedPos = null;
        //              figures = [];
        //         }
                 
        //     }
        // }
    } 
    var pos;
    if(figures !== undefined){
        pos = figures.find(x => x.pos[0] === position[0] && x.pos[1] === position[1]);    
    }
    else pos = undefined;
    var name;
    if (position[0] === selected[0] && position[1] === selected[1])  name = "chess-tile " + color +" selected";
    else name = "chess-tile " + color;
    
    return (<div onClick={handleClick}  id={position} className={name}><Figure figure={pos} setSelected={setSelected} highlightTiles={highlightTiles} /> </div>);
}

export default ChessTile;