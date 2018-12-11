let Display = require('./display.js')

module.exports = class Calculator {
    constructor(display) {
        var me = this
        
        if (!!display && typeof (display) !== 'Display') {
            throw new TypeError('val must be a string or number')
        }

        if (!!display) {
            me.display = display
        }
        else {
            me.display = new Display()
        }
        
        me.currentOp = ''
        me.currentVal = ''

        var buttons = document.querySelectorAll('div[data-cmd]')
        for (var i = 0; i < buttons.length; i++) {
            buttons[i].addEventListener('click', function () {
                var pressed = this.getAttribute('data-cmd')
                console.log('Pressed ' + pressed)
                me.buttonClick(pressed)
                return true
            })
        }
    }

    buttonClick(val) {
        if (typeof (val) !== 'string') {
            throw new TypeError('val must be a string')
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
                this.currentVal += val
                break
            case 'Ovr':
                this.currentVal += '/'
                break
            case '+':
            case '-':
            case '*':
            case '/':
                this.currentVal = ''
                this.currentOp = val
                //
                break
            case '':
            case '':
            case '':
            case '=':
                this.currentOp = ''
                this.currentVal = ''
                // calculate
                break
            default:
                throw new Error('Value outside the valid range.')
        }

        this.display.setValue(this.currentVal, this.currentOp)
    }

    
}