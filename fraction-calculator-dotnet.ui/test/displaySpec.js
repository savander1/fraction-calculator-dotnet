const assert = require('assert')
let Display = require('../display.js')

describe('display.js', function(){

    before(function () {
        var html = '<!DOCTYPE html>'
        html += '<div class="screen extra-long">'
        html += '<div id="neg"></div>'
        html += '<div id="num"></div>'
        html += '<div id="currentOp"></div>'
        html += '</div>'

        this.jsdom = require('jsdom-global')(html)

      })
      
      after(function () {
        this.jsdom()
      })

    describe('setValue', function() {

        it('should set the negative sign on a negative number', function(){
            var display = new Display();

            display.setValue('-1');

            var neg = document.getElementById('neg');
            assert.equal('-', neg.innerHTML);
        })
    })
})