var buttonDir = { north: 'down', south: 'up', east: 'left', west: 'right' };
$.extend($.fn.layout.paneldefaults, {
    onBeforeCollapse: function () {
        /**/
        var popts = $(this).panel('options');
        var dir = popts.region;
        var btnDir = buttonDir[dir];
        if (!btnDir) return false;

        setTimeout(function () {
            var pDiv = $('.layout-button-' + btnDir).closest('.layout-expand').css({
                textAlign: 'center', lineHeight: '18px', fontWeight: 'bold'
            });

            if (popts.title) {
                var vTitle = popts.title;
                if (dir == "east" || dir == "west") {
                    var vTitle = popts.title.split('').join('<br/>');
                    pDiv.find('.panel-body').html(vTitle);
                } else {
                    $('.layout-button-' + btnDir).closest('.layout-expand').find('.panel-title')
                    .css({ textAlign: 'left' })
                    .html(vTitle)
                }

            }
        }, 100);

    }
});
