function Figure(props){
    const pos = figures.find(x => x.pos[0] === Number(props.props[0]) && x.pos[1] === props.props[1]);
    if (pos !== undefined)
    switch(pos.name){
        case "pawn":
            return (
                    <button className={"button "} onClick={(event) => event.stopPropagation()}>
                        <Pawn props={pos}/>
                    </button>
            );
        case "knight":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Knight props={pos}/>
                </ button>
            );
        case "rook":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Rook props={pos}/>
                </button>
            );
        case "bishop":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Bishop props={pos}/>
                </button>
            );
        case "queen":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <Queen props={pos}/>
                </button>
            );
        case "king":
            return (
                <button className={"button "} onClick={(event) => event.stopPropagation()}>
                <King props={pos}/>
                </button>
            );
        default:
            return null;
    }
    return null;
}

function Pawn(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return(
        <div className={"figure " +  props.props.color+ "-pawn"} onClick={(event) => handleClick(event, props.props.pos)}>
        </div>
    )
}

function Knight(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return (<div className={"figure " +  props.props.color+ "-knight"  } onClick={(event) => handleClick(event, props.props.pos)}></div>)
}

function Rook(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return (<div className={"figure " +  props.props.color+ "-rook"} onClick={(event) => handleClick(event, props.props.pos)} ></div>)
}

function Queen(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return (<div className={"figure " +  props.props.color+ "-queen"} onClick={(event) => handleClick(event, props.props.pos)} ></div>)
}

function King(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return (<div className={"figure " +  props.props.color+ "-king"} onClick={(event) => handleClick(event, props.props.pos)} ></div>)
}
function Bishop(props) {
    const handleClick = (event, pos) => {
        event.stopPropagation();
        if(event.target === selectedFigure){
            selectedFigure = null;
            event.target.parentNode.style.backgroundColor="white";
            const f = figures.find(x => x.pos === pos);
            unhighlight(f.available_moves);
            selectedPos = null;
        }
        else if(selectedFigure === null){
            selectedFigure = event.target;    
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
        else {
            const p = figures.find(x => x.pos === selectedPos);
            if(p !== undefined)
                unhighlight(p.available_moves);
            selectedFigure.parentNode.style.backgroundColor="white";
            selectedFigure = event.target;
            selectedFigure.parentNode.style.backgroundColor="yellow";
            const f = figures.find(x => x.pos === pos);
            highlight(f.available_moves);
            selectedPos = pos;
        }
    }
    return (<div className={"figure " +  props.props.color+ "-bishop"} onClick={(event) => handleClick(event, props.props.pos)}></div>)
}

export default Figure;