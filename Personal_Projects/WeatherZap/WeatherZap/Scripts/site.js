$(function () {

    var query;

    /* Query HTML 5 geolcation permission */
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
                            query = data.location.zip;
                            getWeather(query);
                    });
                });
            }

            /* Auto complete location query */
            $('#query_input').keypress(function (e) {

                query = $("#query_input").val();
         
                if (query.length > 3) {

                    $.getJSON("http://autocomplete.wunderground.com/aq?query=" + query + "&cb=?", function () { })
                        .done(function (data) {

                            var resultCount = data.RESULTS.length
                            
                            $("#location_list").empty();

                            for (i = 0; i <= resultCount; i++) {

                                if (i > 4) 
                                    break;
                                
                                var locationName = data.RESULTS[i].name;

                                $("#location_list").append("<option>" + locationName + "</option>");

                            }

                            $("#query_input").on("input", function () {

                                var selection = $(this).val();

                                for (i = 0; i < resultCount; i++) {

                                    if (selection === data.RESULTS[i].name) 
                                        getWeather(data.RESULTS[i].zmw);

                                }
                            })

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