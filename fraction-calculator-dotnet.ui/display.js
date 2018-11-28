
module.exports =  class Display {
    constructor(id) {
        this.id = id;

    }

    setDisplay(val) {
        var html = function(val){
            var ret = '';
            if (val.indexOf('-') !== -1){
                ret += '<span class="neg">-</span>'
            }

            if (val.indexOf('/') !== -1){
                var parts = val.split('/');
                ret += '<div class="vert">'
                ret += '<span>' + parts[0] + '</span>'
                ret += '<span><hr /></span>'
                ret += '<span>' + parts[1] + '</span>'
                ret += '</div>'
            }
            return ret;
        }

        var elm = document.getElementById(this.id);
        elm.innerHTml = html(val);
    }

    clear(){
        this.setDisplay('')
    }
}