let Display = require('./display.js');
let edge = require('edge');

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
        
        this.operation = '';
        this.buffer = '';

        let buttons = document.querySelectorAll('div[data-cmd]');
        buttons.forEach( (button) => {
            button.addEventListener('click',  this.buttonClick.bind(this, button.getAttribute('data-cmd')), false);
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
            case '9':
                this.buffer += val;
                break;
            case 'Ovr':
                this.buffer += '/';
                break;
            case '+':
            case '-':
            case '*':
            case '/':
                this.addFraction(this.buffer);
                this.addOperation(val);
                this.buffer = '';
                this.operation = val;
                break;
            case 'Neg':
                this.buffer = '-' + this.buffer;
                break;
            case 'AC':
                this.clear(true);
                break;
            case 'C':
                this.clear(false);
                break;
            case '=':
                this.operation = '';
                this.buffer = this.calculate();
                break;
            default:
                throw new Error('Value [' + val + '] outside the valid range.');
        }

        this.display.setValue(this.buffer, this.operation);
    }

    clear(all) {
        // edge function here, but for now ...
        this.display.setValue('',this.operation);

        var f = edge.func(function () {/*
            async (input) => 
            { 
                return ".NET welcomes " + input.ToString(); 
            }
        */});

        console.log(f(all));
    }

    addFraction(fraction) {
        // edge function here
        
    }

    addOperation(operation) {
        // edge function here
    }

    calculate() {
        // edge function here
        return 3;
    }
};