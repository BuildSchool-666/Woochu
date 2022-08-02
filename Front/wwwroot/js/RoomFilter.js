new Vue({
    el: '#app',
    data: {
        shoes: [
            { name: 'N19 Beige Narrow fit', size: [35, 35.5, 36], heel: [6.5], color: ['beige'] },
            { name: 'M02 Brown Lace', size: [36, 36.5, 37], heel: [7.5], color: ['brown'] },
            { name: 'M04 Purple & Brown', size: [37, 37.5, 38], heel: [7], color: ['purple', 'brown'] },
            { name: 'M19 Brown', size: [39, 39.5, 40], heel: [7.5], color: ['brown'] },
            { name: 'M20 Copper', size: [40, 40.5, 41], heel: [6.5], color: ['copper'] },
            { name: 'M31 Black Leather', size: [35, 37, 39], heel: [7], color: ['black'] },
            { name: 'M31 Black', size: [36, 38, 39], heel: [7], color: ['black'] },
            { name: 'M44 Silver Glitter', size: [35.5, 38.5, 40.5], heel: [6.5], color: ['silver'] },
        ],
        checked: {
            size: [],
            heel: [],
            color: []
        }
    },
    computed: {
        size: function () {
            return this.available('size').sort((a, b) => a - b);
        },
        heel: function () {
            return this.available('heel').sort((a, b) => a - b);
        },
        color: function () {
            return this.available('color').sort((a, b) => a < b ? -1 : 1);
        }
    },
    methods: {
        available: function (category) {
            const categorySet = new Set([]);
            for (var i = 0; i < this.shoes.length; i++) {
                this.shoes[i][category].forEach(el =>
                    categorySet.add(el));
            }
            return [...categorySet];
        },
        visible: function (size, heel, color) {
            const sizes = this.checked.size.length ? _.intersection(size, this.checked.size).length : true;
            const heels = this.checked.heel.length ? _.intersection(heel, this.checked.heel).length : true;
            const colors = this.checked.color.length ? _.intersection(color, this.checked.color).length : true;
            if (sizes && heels && colors) {
                return true;
            } else {
                return false;
            }
        }
    },
    filters: {
        capitalize: function (value) {
            if (!value) return '';
            value = value.toString();
            return value.charAt(0).toUpperCase() + value.slice(1);
        }
    }
})