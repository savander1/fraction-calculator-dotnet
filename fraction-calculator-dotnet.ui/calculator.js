let Display = require('./display.js');

module.exports =  class Calculator
{
    constructor() {
        var me = this;
        me.display = new Display();
        me.currentOp = '';
        me.currentVal = ''; 

        var buttons = document.querySelectorAll('div[data-cmd]');
        for (var i  = 0; i < buttons.length; i++)
        {
            buttons[i].addEventListener('click', function(){
                var pressed = this.getAttribute('data-cmd');
                console.log('Pressed ' + pressed);
                me.buttonClick(pressed);
                return true;
            })
        }
    }

    buttonClick(val) {
        this.display.setValue(val);
    }
}