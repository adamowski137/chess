function GameOver({isMate}){
    console.log(isMate);
    if(isMate === false || isMate === undefined || isMate === null) return [];
    else return(
    <div className="game-over" >
        GG
    </div>
        )
}

export default GameOver;