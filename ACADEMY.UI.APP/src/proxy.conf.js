const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7243';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/api/alertas",
      "/api/auth",
      "/api/avales",
      "/api/buscador",
      "/api/clientes",
      "/api/clientes-eventos",
      "/api/combobox",
      "/api/contactos",
      "/api/correos",
      "/api/documentos",
      "/api/erps",
      "/api/facturar-pedidos",
      "/api/facturar-recurrencias",
      "/api/facturas",
      "/api/formapago",
      "/api/grupos",
      "/api/home",
      "/api/logs",
      "/api/partners",
      "/api/pedido",
      "/api/pedidos",
      "/api/pedido-shared",
      "/api/productos",
      "/api/proyectos",
      "/api/recurrencias",
      "/api/recurrencias-pendientes",
      "/api/roles",
      "/api/sesiones",
      "/api/usuarios"
   ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
