﻿var Criar = function () {
    tinymce.init({
        selector: "#textarea", setup: function (editor) {
            editor.on('change', function () {
                editor.save();
            });
        }
    });
};

var Editar = function () {
    tinymce.init({
        selector: "#textarea",
        plugins: ['advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker',
            'searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking',
            'table emoticons template paste help'],
        toolbar: 'undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | '
            + 'bullist numlist outdent indent | link image | print preview media fullpage | '
            + 'forecolor backcolor emoticons | help',
        menu: { favs: { title: 'My Favorites', items: 'code visualaid | searchreplace | spellchecker | emoticons' } },
        menubar: 'favs file edit view insert format tools table help', content_css: '/css/site.css',
        setup: function (editor) { editor.on('change', function () { editor.save(); }); }
    });
};