var map = new $.jmelosegui.GoogleMap('#mapContainer');
var markers = [];
var addressName;

function onAddressInput() {
    var address = $('#address-id').val();
    var addressUrl = $('#addressUrl').val();

    map.ajax({
        url: addressUrl,
        type: 'Get',
        data: { address: address },
        success: function (data) {
            addressName = address;
        }
    })
};

function mapAddressClick(args) {
    clearMarkers();
    placeMarker(args.latLng, args.map, 'Retaurant location');

    var lat = args.latLng.lat();
    var lng = args.latLng.lng();

    $('#lat-id').val(lat);
    $('#lng-id').val(lng);
}



function mapCurrentLocationLoaded(args) {
    placeMarker(args.map.center, args.map, 'Your location');

    var lat = args.map.center.lat();
    var lng = args.map.center.lng();

    $('#lat-id').val(lat);
    $('#lng-id').val(lng);
}

function mapSendCurrentLocation(args) {
    var lat = args.map.center.lat();
    var lng = args.map.center.lng();

    console.log("lol");

    map.ajax({
        url: '/Restaurant/ClosestRestaurants',
        type: 'Get',
        data: { latitude: lat, longitude: lng }
    })
}

function mapAddressLoaded(args) {
    placeMarker(args.map.center, args.map, addressName);

    var lat = args.map.center.lat();
    var lng = args.map.center.lng();

    $('#lat-id').val(lat);
    $('#lng-id').val(lng);
}

function placeMarker(position, map, content) {
    var marker = new google.maps.Marker({
        position: position,
        map: map
    });

    var infowindow = new google.maps.InfoWindow({
        content: content
    });

    marker.addListener('click', function () {
        infowindow.open(map, marker);
    });

    infowindow.open(map, marker);
    map.panTo(position);
    markers.push(marker);
}

function clearMarkers() {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(null);
    }
}