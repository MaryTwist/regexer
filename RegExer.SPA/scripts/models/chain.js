define(function () {
    
    return function Chain(_chainId, _name, _description, _made, _modified) {
        this.chainId = _chainId;
        this.name = _name;
        this.description = _description;
        this.made = _made;
        this.modified = _modified;
    }

});