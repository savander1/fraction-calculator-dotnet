let Display = require('./display.js');

module.exports =  class Calculator
{
    constructor(button) {
        var me = this;
        me.display = new Display();
        
        var buttons = document.querySelectorAll(button);
        for (var i  = 0; i < buttons.length; i++)
        {
            buttons[i].addEventListener('click', function(){
                var pressed = this.getAttribute('data-cmd');
                console.log('Pressed ' + pressed);
                return true;
            })
        }
    }

    
    
}