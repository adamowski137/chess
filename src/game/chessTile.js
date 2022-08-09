import Figure from "./figure";
function ChessTile({figures, position, color, selected, setSelected, highlightTiles, highlighted, sendMove, isChecked}){
    const handleClick = (event) => {
        event.stopPropagation();
        const pos = highlighted.find(x => x.xPos === position[0] && x.yPos === position[1]);
        if(selected !== undefined && pos !== undefined){
            sendMove(selected, position);
        }
        
        // 
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
    //console.log(highlighted);
    var pos;
    var isHighlited;
    var name;
    if(figures !== undefined){
        pos = figures.find(x => x.xPos === position[0] && x.yPos === position[1]);    
    }
    if (position[0] === selected[0] && position[1] === selected[1])  name = "chess-tile " + color +" selected";
    else name = "chess-tile " + color;
    if(highlighted !== undefined){
        isHighlited = highlighted.find(x => x.xPos === position[0]&& x.yPos ===  position[1]);
    }
    if (isHighlited !== undefined) name = name + " highlight";

    if(isHighlited === undefined && isChecked.xPos === position[0] && isChecked.yPos === position[1])
        name = name + " checked";
    return (<div onClick={handleClick}  id={position} className={name}><Figure figure={pos} setSelected={setSelected} highlightTiles={highlightTiles} /> </div>);
}

export default ChessTile;