define(function () {
    return function Script(_id, _name, _description, _search, _replace, _made, _modified) {

        let self = this;

        this.ScriptId = _id;
        this.Name = _name;
        this.Description = null;
        this.SearchPattern = _search;
        this.ReplacePattern = _replace;
        this.Made = null;
        this.Modified = _modified;

    }
});