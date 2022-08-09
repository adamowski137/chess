function ValueCounter({value})
{
    return(
        <div className="display-counter">
            <div className="counter">
                <div className="bar" id="bar"></div>
            </div>
            {value}
        </div>
    )
}


export default ValueCounter;