const assert = require('assert')
const Calculator = require('../calculator.js')
const jsdom = require('jsdom-global')

describe('caclulator.js', function() {
    describe('constructor', function() {
        it ('should throw when false is passed', function() {
            assert.throws(() => {new Calculator(false)})
        })
        it ('should throw when true is passed', function() {
            assert.throws(() => {new Calculator(true)})
        })
        it ('should throw when undefined is passed', function() {
            var undefined
            assert.throws(() => {new Calculator(undefined)})
        })
        it ('should throw when number is passed', function() {
            assert.throws(() => {new Calculator(1)})
        })
        it ('should throw when string is passed', function() {
            assert.throws(() => {new Calculator('foo')})
        })
        it('should add a click listener to all buttons', function() {
            this.enableTimeouts(false)
            var html = '<div id="test-button" class="button" data-cmd="1"></div>'
            jsdom(html)

            var calc = new Calculator()
            
            var button = document.getElementById('test-button')
            button.click()

            assert.deepStrictEqual('1', calc.currentVal)
        })
    })
    describe('buttonClick', function() {
        it ('should throw when null is passed', function() {
            var calc = new Calculator()

            assert.throws(() => {calc.buttonClick(null)})
        })
        it ('should throw when false is passed', function() {
            var calc = new Calculator()

            assert.throws(() => {calc.buttonClick(false)})
        })
        it ('should throw when true is passed', function() {
            var calc = new Calculator()

            assert.throws(() => {calc.buttonClick(true)})
        })
        it ('should throw when undefined is passed', function() {
            var calc = new Calculator()
            var undefined
            assert.throws(() => {calc.buttonClick(undefined)})
        })
        it ('should throw when number is passed', function() {
            var calc = new Calculator()

            assert.throws(() => {calc.buttonClick(1)})
        })
        it ('should throw when empty is passed', function() {
            var calc = new Calculator()

            assert.throws(() => {calc.buttonClick('')})
        })
    })
})
