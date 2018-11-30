let Display = require('./display.js');

module.exports =  class Calculator
{
    constructor(display, button) {
        this.display = new Display(display);
        
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