module.exports = class Display {

    constructor() {
        this.setValue('', '')
    }

    setValue(val, op) {
        if (typeof (val) !== 'string' && typeof (val) !== 'number') {
            throw new TypeError('val must be a string or number')
        }

        if (op !== null && typeof (op) !== 'undefined' && typeof (op) !== 'string') {
            throw new TypeError('op must be a string')
        }

        var setNegative = function (v) {
            var content = ''
            if (v.indexOf('-') !== -1) {
                content = '&#150;'
            }

            var neg = document.getElementById('neg')
            neg.innerHTML = content
        }

        var setOp = function (o) {
            var operation = ''
            switch (o) {
            case '+':
                operation = '&#43;'
                break
            case '-':
                operation = '&#150;'
                break
            case '*':
                operation = '&#215;'
                break
            case '/':
                operation = '&#247;'
                break
            case '=':
                operation = '&#61;'
                break
            }

            document.getElementById('currentOp').innerHTML = operation
        }

        var setNumber = function (v) {
            v = v.replace('-', '')

            var fraction = '';
            if (v.indexOf('/') !== -1) {
                var parts = v.split('/')
                fraction += '<div class="vert">'
                fraction += '<span>' + parts[0] + '</span>'
                fraction += '<span>' + parts[1] + '</span>'
                fraction += '</div>'
            } else {
                fraction = v === '' ? '0' : v
            }

            document.getElementById('num').innerHTML = fraction
        }

        setNegative(val.toString())

        if (op) {
            setOp(op.toString())
        }

        setNumber(val.toString())
    }

    clear() {
        this.setValue('0', '')
    }
}