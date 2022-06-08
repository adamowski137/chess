import { useState } from "react";
import Popup from "reactjs-popup"
function PromotePanel({selectedFigure, figures, move}){
    const [popup, setPopup] = useState(false);
    const figure = figures.find(x => x.xPos == selectedFigure[0] && x.yPos == selectedFigure[1] && x.name === "pawn");
    if(figure !== undefined && figure.color === "black" && move[0] == 0 && popup !== true) setPopup(true);
    else if(figure !== undefined && figure.color === "white" && move[0] == 7 && popup !== true) setPopup(true);
    // else if(popup !== false) setPopup(false);
    return (
        <Popup open={popup}>
            <div>twój stary</div>
        </Popup>
    );

}

export default PromotePanel;