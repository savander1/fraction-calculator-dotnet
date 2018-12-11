const assert = require('assert')
const Calculator = require('../calculator.js')
const jsdom = require('jsdom-global')



describe('caclulator.js', function() {
    describe('constructor()', function() {
        
        it('should add a click listener to all buttons', function() {
            this.enableTimeouts(false)
            var html = '<div id="test-button" class="button" data-cmd="1"></div>'
            jsdom(html)

            var calc = new Calculator()
            
            var button = document.getElementById('test-button')
            button.click()

            assert.deepStrictEqual('1', calc.currentVal)
        });
    });
});
