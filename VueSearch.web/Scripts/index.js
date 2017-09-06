new Vue({
    el: "#app",
    data: {
        searchTerm: '',
        products: [],
        searchHeader: '',
        dropDown: 0
    },
    methods: {
        find: function () {
            $.get("/home/getsearchresults", { searchTerm: this.searchTerm }, products => {
                this.products = products;
                this.searchHeader = `Results for "${this.searchTerm}"`
            })
        },
        displayAmount: function () {
            $.get("/home/amounttoshow", { searchTerm: this.searchTerm, num: this.dropDown }, products => {
                this.products = products;
            })
        }
    }
});

