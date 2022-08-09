function Figure({figure, setSelected, highlightTiles}){
    const pos = figure;
    if (pos !== undefined)
    switch(pos.name){
        case "pawn":
            return (
                    <button className={"button "} onClick={(event) =>  event.stopPropagation()}>
                        <Pawn props={pos} isSelected={setSelected} highlightTiles={highlightTiles}/>
                    </button>
            );
        case "knight":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Knight props={pos} isSelected={setSelected} highlightTiles={highlightTiles}/>
                </ button>
            );
        case "rook":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Rook props={pos} isSelected={setSelected} highlightTiles={highlightTiles}/>
                </button>
            );
        case "bishop":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Bishop props={pos} isSelected={setSelected} highlightTiles={highlightTiles}/>
                </button>
            );
        case "queen":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Queen props={pos} isSelected={setSelected} highlightTiles={highlightTiles}/>
                </button>
            );
        case "king":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <King props={pos} isSelected={setSelected} highlightTiles={highlightTiles}/>
                </button>
            );
        default:
            return null;
    }
    return null;
}

function Pawn({props, isSelected, highlightTiles}) {
    const handleClick = (event, pos, moves) => {
        event.stopPropagation();
        isSelected(pos);
        highlightTiles(moves);
        // if(event.target === selectedFigure){
        //     selectedFigure = null;
        //     event.target.parentNode.style.backgroundColor="white";
        //     const f = figures.find(x => x.pos === pos);
        //     unhighlight(f.available_moves);
        //     selectedPos = null;
        // }
        // else if(selectedFigure === null){
        //     selectedFigure = event.target;    
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
        // else {
        //     const p = figures.find(x => x.pos === selectedPos);
        //     if(p !== undefined)
        //         unhighlight(p.available_moves);
        //     selectedFigure.parentNode.style.backgroundColor="white";
        //     selectedFigure = event.target;
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
    }
    return(
        <div className={"figure " +  props.color+ "-pawn"} onClick={(event) => handleClick(event, [props.xPos, props.yPos], props.availablePos)}>
        </div>
    )
}

function Knight({props, isSelected, highlightTiles}) {
    const handleClick = (event, pos, moves) => {
        event.stopPropagation();
        isSelected(pos);
        highlightTiles(moves);
        // event.stopPropagation();
        // if(event.target === selectedFigure){
        //     selectedFigure = null;
        //     event.target.parentNode.style.backgroundColor="white";
        //     const f = figures.find(x => x.pos === pos);
        //     unhighlight(f.available_moves);
        //     selectedPos = null;
        // }
        // else if(selectedFigure === null){
        //     selectedFigure = event.target;    
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
        // else {
        //     const p = figures.find(x => x.pos === selectedPos);
        //     if(p !== undefined)
        //         unhighlight(p.available_moves);
        //     selectedFigure.parentNode.style.backgroundColor="white";
        //     selectedFigure = event.target;
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
    }
    return (<div className={"figure " +  props.color+ "-knight"  } onClick={(event) => handleClick(event, [props.xPos, props.yPos], props.availablePos)}></div>)
}

function Rook({props, isSelected, highlightTiles}) {
    const handleClick = (event, pos, moves) => {
        event.stopPropagation();
        isSelected(pos);
        highlightTiles(moves);
        // event.stopPropagation();
        // if(event.target === selectedFigure){
        //     selectedFigure = null;
        //     event.target.parentNode.style.backgroundColor="white";
        //     const f = figures.find(x => x.pos === pos);
        //     unhighlight(f.available_moves);
        //     selectedPos = null;
        // }
        // else if(selectedFigure === null){
        //     selectedFigure = event.target;    
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
        // else {
        //     const p = figures.find(x => x.pos === selectedPos);
        //     if(p !== undefined)
        //         unhighlight(p.available_moves);
        //     selectedFigure.parentNode.style.backgroundColor="white";
        //     selectedFigure = event.target;
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
    }
    return (<div className={"figure " +  props.color+ "-rook"} onClick={(event) => handleClick(event, [props.xPos, props.yPos], props.availablePos)} ></div>)
}

function Queen({props, isSelected, highlightTiles}) {
    const handleClick = (event, pos, moves) => {
        event.stopPropagation();
        isSelected(pos);
        highlightTiles(moves);
        // event.stopPropagation();
        // if(event.target === selectedFigure){
        //     selectedFigure = null;
        //     event.target.parentNode.style.backgroundColor="white";
        //     const f = figures.find(x => x.pos === pos);
        //     unhighlight(f.available_moves);
        //     selectedPos = null;
        // }
        // else if(selectedFigure === null){
        //     selectedFigure = event.target;    
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
        // else {
        //     const p = figures.find(x => x.pos === selectedPos);
        //     if(p !== undefined)
        //         unhighlight(p.available_moves);
        //     selectedFigure.parentNode.style.backgroundColor="white";
        //     selectedFigure = event.target;
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
    }
    return (<div className={"figure " +  props.color+ "-queen"} onClick={(event) => handleClick(event, [props.xPos, props.yPos], props.availablePos)} ></div>)
}

function King({props, isSelected, highlightTiles}) {
    const handleClick = (event, pos, moves) => {
        event.stopPropagation();
        isSelected(pos);
        highlightTiles(moves);
        // event.stopPropagation();
        // if(event.target === selectedFigure){
        //     selectedFigure = null;
        //     event.target.parentNode.style.backgroundColor="white";
        //     const f = figures.find(x => x.pos === pos);
        //     unhighlight(f.available_moves);
        //     selectedPos = null;
        // }
        // else if(selectedFigure === null){
        //     selectedFigure = event.target;    
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
        // else {
        //     const p = figures.find(x => x.pos === selectedPos);
        //     if(p !== undefined)
        //         unhighlight(p.available_moves);
        //     selectedFigure.parentNode.style.backgroundColor="white";
        //     selectedFigure = event.target;
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
    }
    return (<div className={"figure " +  props.color+ "-king"} onClick={(event) => handleClick(event, [props.xPos, props.yPos], props.availablePos)} ></div>)
}
function Bishop({props, isSelected, highlightTiles}) {
    const handleClick = (event, pos, moves) => {
        event.stopPropagation();
        isSelected(pos);
        highlightTiles(moves);
        // event.stopPropagation();
        // if(event.target === selectedFigure){
        //     selectedFigure = null;
        //     event.target.parentNode.style.backgroundColor="white";
        //     const f = figures.find(x => x.pos === pos);
        //     unhighlight(f.available_moves);
        //     selectedPos = null;
        // }
        // else if(selectedFigure === null){
        //     selectedFigure = event.target;    
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
        // else {
        //     const p = figures.find(x => x.pos === selectedPos);
        //     if(p !== undefined)
        //         unhighlight(p.available_moves);
        //     selectedFigure.parentNode.style.backgroundColor="white";
        //     selectedFigure = event.target;
        //     selectedFigure.parentNode.style.backgroundColor="yellow";
        //     const f = figures.find(x => x.pos === pos);
        //     highlight(f.available_moves);
        //     selectedPos = pos;
        // }
    }
    return (<div className={"figure " +  props.color+ "-bishop"} onClick={(event) => handleClick(event, [props.xPos, props.yPos], props.availablePos)}></div>)
}


export default Figure;