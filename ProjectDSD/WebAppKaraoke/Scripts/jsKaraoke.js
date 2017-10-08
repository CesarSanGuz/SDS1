(function (global, $) {
    var telerikDemo = global.telerikDemo = {};

    var itemsCount = 0;

    updateCart = function (sender, args) {
        addToItems();
        updateItemCounter();
        setItemCounterVisibility();
    };

    addToItems = function () {
        itemsCount++;
    };

    updateItemCounter = function () {
        $(".products-count").html(itemsCount);
    };

    setItemCounterVisibility = function () {
        var $productsCounter = $(".products-count");
        if (itemsCount > 0 && $productsCounter.css("visibility") === "hidden") {
            $productsCounter.css("visibility", "visible");
        }
    };

    telerikDemo.updateCart = updateCart;

})(window, $telerik.$);