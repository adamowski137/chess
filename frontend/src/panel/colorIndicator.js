function ColorIndicator({color}){
    if  (color === null || color === undefined) return [];
    if  (color === true)    return (<div className="box white"><span>MOVE</span></div>);
    if  (color === false)   return (<div className="box black"><span>MOVE</span></div>);
}

export default ColorIndicator;