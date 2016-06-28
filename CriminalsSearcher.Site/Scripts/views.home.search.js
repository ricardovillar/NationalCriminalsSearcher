(function () {

    $(function () {
        configSlider("slider-age", "Age", "MinimumAge", "MaximumAge", 0, 200);
        configSlider("slider-height", "Height", "MinimumHeight", "MaximumHeight", 0, 100);
        configSlider("slider-weight", "Weight", "MinimumWeight", "MaximumWeight", 0, 700);

        $("#MaxResults").spinner({ min: 1 });
        $("#MaxResults").bind("keydown", function (event) {
            event.preventDefault();
        });

        function configSlider(sliderElement, rangeDisplayElement, viewModelMinimumInput, viewModelMaximumInput, minValue, maxValue) {
            $("#" + sliderElement).slider({
                range: true,
                min: minValue,
                max: maxValue,
                values: [minValue, maxValue],
                slide: function (event, ui) {
                    $("#" + rangeDisplayElement).val(ui.values[0] + " - " + ui.values[1]);
                    $("#" + viewModelMinimumInput).val(ui.values[0]);
                    $("#" + viewModelMaximumInput).val(ui.values[1]);
                }
            });
            $("#" + rangeDisplayElement).val($("#" + sliderElement).slider("values", 0) +
              " - " + $("#" + sliderElement).slider("values", 1));
        }

    });

})();
