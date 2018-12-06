const assert = require('assert')
const Display = require('../display.js')
const jsdom = require('jsdom-global')

describe('display.js', function(){

    before(function () {
        this.enableTimeouts(false)
        var html = '<!DOCTYPE html>'
        html += '<div class="screen extra-long">'
        html += '<div id="neg"></div>'
        html += '<div id="num"></div>'
        html += '<div id="currentOp"></div>'
        html += '</div>'

        this.dom = jsdom(html)
        this.display = new Display();
      });
      
      after(function () {
        this.dom = jsdom()
        this.display = null
      });

    describe('setValue', function() {

        it('should set the negative sign on a negative number', function(){
            this.display.setValue('-1');

            var neg = document.getElementById('neg');
            assert.ok(escape(neg.innerHTML) === '%u2013');
        })

        it('should not set the negative sign on a positive number', function(){
            this.display.setValue('1');

            var neg = document.getElementById('neg');
            assert.ok(escape(neg.innerHTML) === '');
        })

        it('should correctly display whole number passed as string', function(){
            this.display.setValue('1');

            var neg = document.getElementById('num');
            assert.ok(escape(neg.innerHTML) === '1');
        })

        it('should correctly display whole number passed as number', function(){
            this.display.setValue(1);

            var neg = document.getElementById('num');
            assert.ok(escape(neg.innerHTML) === '1');
        })

        it('should correctly display fraction', function(){
            let expected = '<div class="vert"><span>1</span><span>2</span></div>'
            this.display.setValue('1/2');

            var neg = document.getElementById('num');
            assert.ok(neg.innerHTML === expected);
        })
        
        // test each operation displays as expected
        // test failure cases: null passed, undefined passed, false passed, test non string values

    })
})