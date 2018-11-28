
module.exports =  class Display {
    constructor(id) {
        this.id = id;
    }

    setDisplay(val) {
        var html = function(val){
            var ret = '';
            if (val.indexOf('-') !== -1){
                ret += '<span class="neg">-</span>'
                val = val.replace('-', '');
            }


            if (val.indexOf('/') !== -1){
                var parts = val.split('/');
                ret += '<span class="vert">'
                ret += '<span>' + parts[0] + '</span>'
                ret += '<span><hr /></span>'
                ret += '<span>' + parts[1] + '</span>'
                ret += '</span>'
            }
            return ret;
        }

        var elm = document.getElementById(this.id);
        elm.innerHTML = html(val);
    }

    clear(){
        this.setDisplay('')
    }
}