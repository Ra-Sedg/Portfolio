$(function () {

    var zipcode;
    console.log("site.js loaded");

    navigator.permissions.query({ name: 'geolocation' })
        .then(function (permissionStatus) {

            console.log(permissionStatus.state);

            /* geolocation is available */
            if (permissionStatus.state === "granted" || permissionStatus.state === "prompt" ) {

                navigator.geolocation.getCurrentPosition(function (position) {

                    var lattitude = position.coords.latitude;
                    var longitude = position.coords.longitude;

                    $.getJSON("http://api.wunderground.com/api/8e2d1db7242415ea/geolookup/q/" +
                        lattitude + "," + longitude + ".json", function () { })
                        .done(function (data) {

                            zipcode = data.location.zip;
                            console.log(zipcode);
                            getWeather(zipcode);

                        });
                });
            }

            $('#zip_input').keypress(function (e) {

                zipcode = $("#zip_input").val();

                /* Enter was pressed */
                if (e.which === 13) {
                    console.log(zipcode);
                    getWeather(zipcode);
                } else {

                    $.getJSON("http://autocomplete.wunderground.com/aq?query=" + zipcode + "&cb=?", function () {
                    }).done(function (result) {
                        console.log(result);
                    });
                    

                }
            });

        });


    function getWeather(zipcode) {

        $.get("http://api.wunderground.com/api/8e2d1db7242415ea/conditions/q/" +
            zipcode + ".json", function () { })
            .done(function (data) {

                console.log(data);

                $("#location").text("Location: " +
                    data.current_observation.display_location.city + ", " +
                    data.current_observation.display_location.state);

                $("#temp_f").text("Tempurature: " + data.current_observation.temp_f +
                    String.fromCharCode(176));

                $("#forcast_img").attr("src", data.current_observation.icon_url);

                $("#forcast_text").text(data.current_observation.icon);
            });

    }
});