let Display = require('./display.js');

module.exports = class Calculator {
    constructor(display) {
        if (!!display && !(display instanceof Display)) {
            throw new TypeError('val must be an object of type Display');
        }

        if (!!display) {
            this.display = display;
        }
        else {
            this.display = new Display();
        }
        
        this.currentOp = '';
        this.currentVal = '';

        let buttons = document.querySelectorAll('div[data-cmd]');
        buttons.forEach( (button) => {
            button.addEventListener('click', this.buttonClick(button.getAttribute('data-cmd')), true);
        });
    }

    buttonClick(val) {
        if (typeof (val) !== 'string') {
            throw new TypeError('val must be a string');
        }

        switch (val)
        {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
                this.currentVal += val;
                break;
            case 'Ovr':
                this.currentVal += '/';
                break;
            case '+':
            case '-':
            case '*':
            case '/':
                this.currentVal = '';
                this.currentOp = val;
                //
                break;
            case 'Neg':
            case 'AC':
            case 'C':
                break;
            case '=':
                this.currentOp = '';
                this.currentVal = '';
                // calculate
                break;
            default:
                throw new Error('Value outside the valid range.');
        }

        this.display.setValue(this.currentVal, this.currentOp);
    }
};