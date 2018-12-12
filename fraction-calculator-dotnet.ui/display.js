module.exports =  class Display {

    constructor() {
        this.setValue('', '');
    }

    setValue(val, op) {
        if (typeof (val) !== 'string' && typeof (val) !== 'number') {
            throw new TypeError('val must be a string or number. [' + typeof (val) +']');
        }

        if (op !== null && typeof (op) !== 'undefined' && typeof (op) !== 'string') {
            throw new TypeError('op must be a string');
        }

        let me = this;

        let setNegative = (v) => {
            let content = '';
            if (v.indexOf('-') !== -1) {
                content = '&#150;';
            }
            
            me.setHtml('neg', content);
        };

        let setOp = (o) => {
            let operation = '';
            switch (o) {
            case '+':
                operation = '&#43;';
                break;
            case '-':
                operation = '&#150;';
                break;
            case '*':
                operation = '&#215;';
                break;
            case '/':
                operation = '&#247;';
                break;
            case '=':
                operation = '&#61;';
                break;
            default:
                operation = '';
                break;
            }

            me.setHtml('currentOp', operation);
        };

        let setNumber = (v) => {
            v = v.replace('-', '');

            let fraction = '';
            if (v.indexOf('/') !== -1) {
                let parts = v.split('/');
                fraction += '<div class="vert">';
                fraction += '<span>' + parts[0] + '</span>';
                fraction += '<span>' + parts[1] + '</span>';
                fraction += '</div>';
            } else {
                fraction = v === '' ? '0' : v;
            }

            me.setHtml('num', fraction);
        };

        setNegative(val.toString());

        setOp(op);

        setNumber(val.toString());
    }

    clear() {
        this.setValue('0', '');
    }

    setHtml(id, val) {
        let elm = document.getElementById(id);

        if (elm){
            elm.innerHTML = val;
        }
    }
};