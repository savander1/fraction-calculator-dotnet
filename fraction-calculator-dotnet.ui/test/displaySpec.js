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

        it('should correctly display operation: +', function(){
            this.display.setValue('', '+');

            var neg = document.getElementById('currentOp');
            assert.ok(escape(neg.innerHTML) === '+');
        })

        it('should correctly display operation: -', function(){
            this.display.setValue('', '-');

            var neg = document.getElementById('currentOp');
            assert.ok(escape(neg.innerHTML) === '%u2013');
        })

        it('should correctly display operation: *', function(){
            this.display.setValue('', '*');

            var neg = document.getElementById('currentOp');
            assert.ok(escape(neg.innerHTML) === '%D7');
        })

        it('should correctly display operation: /', function(){
            this.display.setValue('', '/');

            var neg = document.getElementById('currentOp');
            assert.ok(escape(neg.innerHTML) === '%F7');
        })

        it('should correctly display operation: =', function(){
            this.display.setValue('', '=');

            var neg = document.getElementById('currentOp');
            debugger
            assert.ok(escape(neg.innerHTML) === '%3D');
        })

        it('should throw when null passed as fraction', function(){
            
            assert.throws(() => { this.display.setValue(null) })
        })

        it('should throw when undefined passed as fraction', function(){
            
            var undefined;
            assert.throws(() => { this.display.setValue(undefined) })
        })

        it('should throw when true passed as fraction', function(){
            
            assert.throws(() => { this.display.setValue(true) })
        })

        it('should throw when false passed as fraction', function(){
            
            assert.throws(() => { this.display.setValue(false) })
        })
        
        it('should throw when true passed as operation', function(){
            
            assert.throws(() => { this.display.setValue(1, true) })
        })

        it('should throw when false passed as operation', function(){
            
            assert.throws(() => { this.display.setValue(1, false) })
        })

        it('should throw when number passed as operation', function(){
            
            assert.throws(() => { this.display.setValue(1, 1) })
        })

    })
})