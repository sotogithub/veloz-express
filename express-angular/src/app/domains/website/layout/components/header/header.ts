import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header-website',
  imports: [RouterLink],
  host: {
    class:
      'fixed inset-x-0 top-0 z-50 border-b border-slate-200/60 bg-white/70 backdrop-blur-xl',
  },
  template: `
    <nav
      class="mx-auto flex h-16 max-w-7xl items-center justify-between px-6 lg:px-8"
    >
      <a
        href="#"
        class="flex items-center gap-2"
      >
        <div
          class="flex h-9 w-9 items-center justify-center rounded-xl bg-gradient-to-br from-orange-500 to-rose-500 shadow-lg shadow-orange-500/30"
        >
          <svg
            class="h-5 w-5 text-white"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="2.5"
            stroke-linecap="round"
            stroke-linejoin="round"
          >
            <path d="M3 12h14l-3-3m3 3-3 3" />
            <circle
              cx="19"
              cy="6"
              r="2"
            />
          </svg>
        </div>
        <span class="text-xl font-bold tracking-tight"
          >Veloz<span class="text-orange-500">Express</span></span
        >
      </a>

      <div
        class="hidden items-center gap-8 text-sm font-medium text-slate-600 md:flex"
      >
        <a
          href="#servicios"
          class="transition hover:text-slate-900"
          >Servicios</a
        >
        <a
          href="#proceso"
          class="transition hover:text-slate-900"
          >Cómo funciona</a
        >
        <a
          href="#beneficios"
          class="transition hover:text-slate-900"
          >Beneficios</a
        >
        <a
          href="#contacto"
          class="transition hover:text-slate-900"
          >Contacto</a
        >
      </div>

      <div class="flex items-center gap-3">
        <a
          [routerLink]="'/admin'"
          class="hidden text-sm font-medium text-slate-700 hover:text-slate-900 sm:inline"
          >Ingresar</a
        >
        <a
          href="#registrar"
          class="inline-flex items-center gap-1.5 rounded-full bg-slate-900 px-4 py-2 text-sm font-semibold text-white shadow-sm transition hover:bg-slate-800"
        >
          Enviar ahora
          <svg
            class="h-4 w-4"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="2"
            stroke-linecap="round"
            stroke-linejoin="round"
          >
            <path d="M5 12h14m-6-6 6 6-6 6" />
          </svg>
        </a>
      </div>
    </nav>
  `,
})
export class HeaderWebsite {}
