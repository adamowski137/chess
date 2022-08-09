function Popup({set, handleQueen, handleRook, handleBishop, handleKnight})
{
    if(set === false)   return ([]);
    if(set === true)    return(
        <div>
            <button onClick={handleQueen}>QUEEN</button>
            <button onClick={handleRook}>ROOK</button>
            <button onClick={handleKnight}>KNIGHT</button>
            <button onClick={handleBishop}>BISHOP</button>
        </div>
    )
}

export default Popup;