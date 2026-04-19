import { Component } from '@angular/core';

@Component({
  selector: 'app-footer-website',
  imports: [],
  host: {
    class: 'bg-slate-950 text-slate-400 pt-20 pb-10',
  },
  template: `

  <footer id="contacto" class="bg-slate-950 text-slate-400 pt-20 pb-10">
    <div class="max-w-7xl mx-auto px-6 lg:px-8">
      <div class="grid md:grid-cols-4 gap-10 pb-12 border-b border-slate-800">
        <div class="md:col-span-1">
          <a href="#" class="flex items-center gap-2 mb-5">
            <div class="w-9 h-9 rounded-xl bg-gradient-to-br from-orange-500 to-rose-500 flex items-center justify-center">
              <svg class="w-5 h-5 text-white" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M3 12h14l-3-3m3 3-3 3"/><circle cx="19" cy="6" r="2"/></svg>
            </div>
            <span class="font-bold text-xl text-white">Veloz<span class="text-orange-500">Express</span></span>
          </a>
          <p class="text-sm leading-relaxed">Tu paquete, en las mejores manos. Envíos rápidos, seguros y trazables.</p>
          <div class="flex items-center gap-3 mt-5">
            <a href="#" class="w-9 h-9 rounded-full bg-slate-800 hover:bg-orange-500 flex items-center justify-center transition">
              <svg class="w-4 h-4 text-white" viewBox="0 0 24 24" fill="currentColor"><path d="M22 12a10 10 0 1 0-11.56 9.88v-6.99H7.9V12h2.54V9.8c0-2.5 1.49-3.89 3.77-3.89 1.09 0 2.24.2 2.24.2v2.46h-1.26c-1.24 0-1.63.77-1.63 1.56V12h2.77l-.44 2.89h-2.33v6.99A10 10 0 0 0 22 12z"/></svg>
            </a>
            <a href="#" class="w-9 h-9 rounded-full bg-slate-800 hover:bg-orange-500 flex items-center justify-center transition">
              <svg class="w-4 h-4 text-white" viewBox="0 0 24 24" fill="currentColor"><path d="M12 2.16c3.2 0 3.58 0 4.85.07 1.17.05 1.8.25 2.23.41.56.22.96.48 1.38.9.42.42.68.82.9 1.38.16.43.36 1.06.41 2.23.06 1.27.07 1.65.07 4.85s0 3.58-.07 4.85c-.05 1.17-.25 1.8-.41 2.23-.22.56-.48.96-.9 1.38-.42.42-.82.68-1.38.9-.43.16-1.06.36-2.23.41-1.27.06-1.65.07-4.85.07s-3.58 0-4.85-.07c-1.17-.05-1.8-.25-2.23-.41a3.71 3.71 0 0 1-1.38-.9 3.71 3.71 0 0 1-.9-1.38c-.16-.43-.36-1.06-.41-2.23-.06-1.27-.07-1.65-.07-4.85s0-3.58.07-4.85c.05-1.17.25-1.8.41-2.23.22-.56.48-.96.9-1.38.42-.42.82-.68 1.38-.9.43-.16 1.06-.36 2.23-.41C8.42 2.17 8.8 2.16 12 2.16zM12 0C8.74 0 8.33 0 7.05.07 5.77.13 4.9.33 4.14.63a5.87 5.87 0 0 0-2.13 1.39A5.87 5.87 0 0 0 .63 4.14C.33 4.9.13 5.77.07 7.05 0 8.33 0 8.74 0 12s0 3.67.07 4.95c.06 1.28.26 2.15.56 2.91a5.87 5.87 0 0 0 1.39 2.13 5.87 5.87 0 0 0 2.13 1.39c.76.3 1.63.5 2.91.56C8.33 24 8.74 24 12 24s3.67 0 4.95-.07c1.28-.06 2.15-.26 2.91-.56a5.87 5.87 0 0 0 2.13-1.39 5.87 5.87 0 0 0 1.39-2.13c.3-.76.5-1.63.56-2.91.07-1.28.07-1.69.07-4.95s0-3.67-.07-4.95c-.06-1.28-.26-2.15-.56-2.91a5.87 5.87 0 0 0-1.39-2.13A5.87 5.87 0 0 0 19.86.63c-.76-.3-1.63-.5-2.91-.56C15.67 0 15.26 0 12 0zm0 5.84a6.16 6.16 0 1 0 0 12.32 6.16 6.16 0 0 0 0-12.32zm0 10.16a4 4 0 1 1 0-8 4 4 0 0 1 0 8zm7.85-10.4a1.44 1.44 0 1 1-2.88 0 1.44 1.44 0 0 1 2.88 0z"/></svg>
            </a>
            <a href="#" class="w-9 h-9 rounded-full bg-slate-800 hover:bg-orange-500 flex items-center justify-center transition">
              <svg class="w-4 h-4 text-white" viewBox="0 0 24 24" fill="currentColor"><path d="M18.244 2.25h3.308l-7.227 8.26 8.502 11.24H16.17l-5.214-6.817L4.99 21.75H1.68l7.73-8.835L1.254 2.25H8.08l4.713 6.231zm-1.161 17.52h1.833L7.084 4.126H5.117z"/></svg>
            </a>
          </div>
        </div>

        <div>
          <h4 class="font-semibold text-white mb-4">Servicios</h4>
          <ul class="space-y-2.5 text-sm">
            <li><a href="#" class="hover:text-white transition">Domicilio a domicilio</a></li>
            <li><a href="#" class="hover:text-white transition">Recojo en agencia</a></li>
            <li><a href="#" class="hover:text-white transition">Envíos empresariales</a></li>
            <li><a href="#" class="hover:text-white transition">Envíos programados</a></li>
          </ul>
        </div>

        <div>
          <h4 class="font-semibold text-white mb-4">Empresa</h4>
          <ul class="space-y-2.5 text-sm">
            <li><a href="#" class="hover:text-white transition">Sobre nosotros</a></li>
            <li><a href="#" class="hover:text-white transition">Agencias</a></li>
            <li><a href="#" class="hover:text-white transition">Trabaja con nosotros</a></li>
            <li><a href="#" class="hover:text-white transition">Preguntas frecuentes</a></li>
          </ul>
        </div>

        <div>
          <h4 class="font-semibold text-white mb-4">Contacto</h4>
          <ul class="space-y-2.5 text-sm">
            <li class="flex items-center gap-2"><svg class="w-4 h-4" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z"/></svg>+51 999 888 777</li>
            <li class="flex items-center gap-2"><svg class="w-4 h-4" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M4 4h16c1.1 0 2 .9 2 2v12c0 1.1-.9 2-2 2H4c-1.1 0-2-.9-2-2V6c0-1.1.9-2 2-2z"/><polyline points="22,6 12,13 2,6"/></svg>hola&#64;velozexpress.com</li>
            <li class="flex items-start gap-2"><svg class="w-4 h-4 mt-0.5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M21 10c0 7-9 13-9 13s-9-6-9-13a9 9 0 0 1 18 0z"/><circle cx="12" cy="10" r="3"/></svg>Av. Principal 123, Centro Logístico</li>
          </ul>
        </div>
      </div>

      <div class="pt-8 flex flex-col md:flex-row items-center justify-between gap-4 text-xs">
        <p>© 2026 VelozExpress. Todos los derechos reservados.</p>
        <div class="flex items-center gap-6">
          <a href="#" class="hover:text-white transition">Términos y condiciones</a>
          <a href="#" class="hover:text-white transition">Privacidad</a>
          <a href="#" class="hover:text-white transition">Cookies</a>
        </div>
      </div>
    </div>
  </footer>

  `
})
export class FooterWebsite {}
