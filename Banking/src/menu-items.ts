export default {
    items: [
        {
            id: 'home',
            title: 'Inicio',
            type: 'group',
            icon: 'icon-navigation',
            children: [
                {
                    id: 'cuentas',
                    title: 'Cuentas',
                    type: 'item',
                    url: '/cuentas',
                    icon: 'feather icon-home',
                    children: [
                        {
                            id: 'cuenta',
                            title: 'SubCuenta',
                            url: '/cuentas/:id',
                            type: 'item'
                        }
                    ]
                }
            ]
        },
        {
            id: 'transf',
            title: 'Transferencias',
            type: 'group',
            icon: 'icon-ui',
            children: [
                {
                    id: 'same',
                    title: 'Entre mis cuentas',
                    type: 'item',
                    icon: 'feather icon-box',
                    url: '/basic/button'
                },
                {
                    id: 'another',
                    title: 'A otros bancos',
                    type: 'item',
                    icon: 'feather icon-box',
                    url: '/basic'
                }
            ]
        },
        {
            id: 'ui-forms',
            title: 'Beneficiarios',
            type: 'group',
            icon: 'icon-group',
            children: [
                {
                    id: 'form-basic',
                    title: 'En BanCovid',
                    type: 'item',
                    url: '/forms/form-basic',
                    icon: 'feather icon-file-text'
                }
            ]
        },
       {
            id: 'pages',
            title: 'Configuración',
            type: 'group',
            icon: 'icon-pages',
            children: [
                {
                    id: 'auth',
                    title: 'Información de usuario',
                    type: 'item',
                    url: '/sample-page',
                    icon: 'feather icon-lock'
                }
            ]
        }
    ]
}