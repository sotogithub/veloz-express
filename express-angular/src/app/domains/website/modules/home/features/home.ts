import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'website-home',
  imports: [RouterLink, MatButton],
  template: `
    <!-- VelozExpress Landing Page -->
<div class="min-h-screen bg-white text-slate-900 antialiased overflow-x-hidden">

  <!-- ============ NAVBAR ============ -->
  <header class="fixed top-0 inset-x-0 z-50 backdrop-blur-xl bg-white/70 border-b border-slate-200/60">
    <nav class="max-w-7xl mx-auto px-6 lg:px-8 h-16 flex items-center justify-between">
      <a href="#" class="flex items-center gap-2">
        <div class="w-9 h-9 rounded-xl bg-gradient-to-br from-orange-500 to-rose-500 flex items-center justify-center shadow-lg shadow-orange-500/30">
          <svg class="w-5 h-5 text-white" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M3 12h14l-3-3m3 3-3 3"/><circle cx="19" cy="6" r="2"/></svg>
        </div>
        <span class="font-bold text-xl tracking-tight">Veloz<span class="text-orange-500">Express</span></span>
      </a>

      <div class="hidden md:flex items-center gap-8 text-sm font-medium text-slate-600">
        <a href="#servicios" class="hover:text-slate-900 transition">Servicios</a>
        <a href="#proceso" class="hover:text-slate-900 transition">Cómo funciona</a>
        <a href="#beneficios" class="hover:text-slate-900 transition">Beneficios</a>
        <a href="#contacto" class="hover:text-slate-900 transition">Contacto</a>
      </div>

      <div class="flex items-center gap-3">
        <a [routerLink]="'/admin'" class="hidden sm:inline text-sm font-medium text-slate-700 hover:text-slate-900">Ingresar</a>
        <a href="#registrar" class="inline-flex items-center gap-1.5 px-4 py-2 rounded-full bg-slate-900 text-white text-sm font-semibold hover:bg-slate-800 transition shadow-sm">
          Enviar ahora
          <svg class="w-4 h-4" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M5 12h14m-6-6 6 6-6 6"/></svg>
        </a>
      </div>
    </nav>
  </header>

  <!-- ============ HERO ============ -->
  <section class="relative pt-32 pb-24 lg:pt-40 lg:pb-32 overflow-hidden">
    <!-- Decorative blobs -->
    <div class="absolute -top-24 -right-24 w-[480px] h-[480px] rounded-full bg-orange-300/30 blur-3xl"></div>
    <div class="absolute top-40 -left-32 w-[420px] h-[420px] rounded-full bg-rose-300/20 blur-3xl"></div>
    <div class="absolute inset-0 bg-[radial-gradient(ellipse_at_top,rgba(255,255,255,0),rgba(255,255,255,0.6))]"></div>

    <div class="relative max-w-7xl mx-auto px-6 lg:px-8 grid lg:grid-cols-2 gap-16 items-center">
      <div>
        <span class="inline-flex items-center gap-2 px-3 py-1 rounded-full bg-orange-100 text-orange-700 text-xs font-semibold mb-6">
          <span class="w-1.5 h-1.5 rounded-full bg-orange-500 animate-pulse"></span>
          Cobertura 24/7 en toda la ciudad
        </span>
        <h1 class="text-5xl lg:text-6xl font-bold tracking-tight leading-[1.05]">
          Tus envíos,
          <span class="relative inline-block">
            <span class="relative z-10 bg-gradient-to-r from-orange-500 to-rose-500 bg-clip-text text-transparent">más rápidos</span>
            <span class="absolute inset-x-0 bottom-1 h-3 bg-orange-200/60 -z-0 rounded"></span>
          </span>
          que nunca.
        </h1>
        <p class="mt-6 text-lg text-slate-600 max-w-xl leading-relaxed">
          Registra tu paquete, nosotros lo recogemos, lo procesamos en nuestro almacén y lo entregamos en la puerta de tu destinatario. Simple, rápido y seguro.
        </p>

        <div class="mt-8 flex flex-wrap gap-3">
          <a href="#registrar" class="inline-flex items-center gap-2 px-6 py-3.5 rounded-full bg-gradient-to-r from-orange-500 to-rose-500 text-white font-semibold shadow-xl shadow-orange-500/30 hover:shadow-2xl hover:shadow-orange-500/40 hover:-translate-y-0.5 transition-all">
            Registrar mi paquete
            <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M5 12h14m-6-6 6 6-6 6"/></svg>
          </a>
          <a href="#proceso" class="inline-flex items-center gap-2 px-6 py-3.5 rounded-full bg-white border border-slate-200 text-slate-900 font-semibold hover:bg-slate-50 transition">
            <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><polygon points="5 3 19 12 5 21 5 3"/></svg>
            Ver cómo funciona
          </a>
        </div>

        <div class="mt-10 flex items-center gap-6 text-sm text-slate-600">
          <div class="flex -space-x-2">
            <div class="w-9 h-9 rounded-full bg-gradient-to-br from-amber-400 to-orange-500 ring-2 ring-white"></div>
            <div class="w-9 h-9 rounded-full bg-gradient-to-br from-rose-400 to-pink-500 ring-2 ring-white"></div>
            <div class="w-9 h-9 rounded-full bg-gradient-to-br from-violet-400 to-indigo-500 ring-2 ring-white"></div>
            <div class="w-9 h-9 rounded-full bg-gradient-to-br from-emerald-400 to-teal-500 ring-2 ring-white"></div>
          </div>
          <div>
            <div class="flex items-center gap-1 text-amber-500">
              <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
              <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
              <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
              <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
              <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            </div>
            <p class="font-medium text-slate-900">+12,000 clientes satisfechos</p>
          </div>
        </div>
      </div>

      <!-- Hero visual: Tracking card -->
      <div class="relative">
        <!-- Floating small card - top -->
        <div class="absolute -top-8 -left-6 lg:-left-10 z-20 bg-white rounded-2xl shadow-2xl shadow-slate-900/10 p-4 border border-slate-100 w-56 hidden sm:block animate-[float_6s_ease-in-out_infinite]">
          <div class="flex items-center gap-3">
            <div class="w-10 h-10 rounded-xl bg-emerald-100 text-emerald-600 flex items-center justify-center">
              <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M20 6 9 17l-5-5"/></svg>
            </div>
            <div>
              <p class="text-xs text-slate-500">Entregado</p>
              <p class="text-sm font-semibold">Hace 2 min</p>
            </div>
          </div>
        </div>

        <!-- Main card -->
        <div class="relative bg-white rounded-3xl shadow-2xl shadow-slate-900/10 border border-slate-100 p-6 lg:p-8">
          <div class="flex items-center justify-between mb-6">
            <div>
              <p class="text-xs text-slate-500 font-medium">SEGUIMIENTO EN TIEMPO REAL</p>
              <p class="text-lg font-bold mt-0.5">Paquete #VX-20486</p>
            </div>
            <span class="px-3 py-1 rounded-full bg-orange-100 text-orange-700 text-xs font-semibold">En camino</span>
          </div>

          <!-- Progress line -->
          <div class="relative">
            <div class="absolute left-[18px] top-4 bottom-4 w-0.5 bg-slate-200"></div>
            <div class="absolute left-[18px] top-4 h-[60%] w-0.5 bg-gradient-to-b from-orange-500 to-rose-500"></div>

            <div class="space-y-5">
              <div class="flex items-start gap-4 relative">
                <div class="w-9 h-9 rounded-full bg-emerald-500 text-white flex items-center justify-center shrink-0 shadow-lg shadow-emerald-500/40 ring-4 ring-white relative z-10">
                  <svg class="w-4 h-4" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="3" stroke-linecap="round" stroke-linejoin="round"><path d="M20 6 9 17l-5-5"/></svg>
                </div>
                <div class="flex-1">
                  <p class="font-semibold text-sm">Paquete registrado</p>
                  <p class="text-xs text-slate-500">Av. Principal 123 · 09:12 AM</p>
                </div>
              </div>

              <div class="flex items-start gap-4 relative">
                <div class="w-9 h-9 rounded-full bg-emerald-500 text-white flex items-center justify-center shrink-0 shadow-lg shadow-emerald-500/40 ring-4 ring-white relative z-10">
                  <svg class="w-4 h-4" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="3" stroke-linecap="round" stroke-linejoin="round"><path d="M20 6 9 17l-5-5"/></svg>
                </div>
                <div class="flex-1">
                  <p class="font-semibold text-sm">Recogido por motorizado</p>
                  <p class="text-xs text-slate-500">Carlos M. · 09:38 AM</p>
                </div>
              </div>

              <div class="flex items-start gap-4 relative">
                <div class="w-9 h-9 rounded-full bg-gradient-to-br from-orange-500 to-rose-500 text-white flex items-center justify-center shrink-0 shadow-lg shadow-orange-500/40 ring-4 ring-white relative z-10 animate-pulse">
                  <svg class="w-4 h-4" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><circle cx="12" cy="12" r="10"/><path d="M12 6v6l4 2"/></svg>
                </div>
                <div class="flex-1">
                  <p class="font-semibold text-sm">En almacén central</p>
                  <p class="text-xs text-slate-500">Procesando · 10:15 AM</p>
                </div>
              </div>

              <div class="flex items-start gap-4 relative opacity-60">
                <div class="w-9 h-9 rounded-full bg-slate-200 text-slate-400 flex items-center justify-center shrink-0 ring-4 ring-white relative z-10">
                  <svg class="w-4 h-4" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M3 9 12 2l9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"/></svg>
                </div>
                <div class="flex-1">
                  <p class="font-semibold text-sm">Entrega a destino</p>
                  <p class="text-xs text-slate-500">Estimado · 11:30 AM</p>
                </div>
              </div>
            </div>
          </div>

          <div class="mt-6 pt-5 border-t border-slate-100 flex items-center justify-between">
            <div class="flex items-center gap-3">
              <div class="w-10 h-10 rounded-full bg-gradient-to-br from-slate-700 to-slate-900 text-white flex items-center justify-center font-bold">CM</div>
              <div>
                <p class="text-sm font-semibold">Carlos M.</p>
                <p class="text-xs text-slate-500">Motorizado asignado</p>
              </div>
            </div>
            <button class="w-10 h-10 rounded-full bg-emerald-500 hover:bg-emerald-600 text-white flex items-center justify-center transition shadow-lg shadow-emerald-500/30">
              <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z"/></svg>
            </button>
          </div>
        </div>

        <!-- Floating small card - bottom -->
        <div class="absolute -bottom-6 -right-4 lg:-right-8 z-20 bg-slate-900 rounded-2xl shadow-2xl p-4 w-60 hidden sm:block animate-[float_6s_ease-in-out_infinite_reverse]">
          <div class="flex items-center gap-3">
            <div class="w-10 h-10 rounded-xl bg-orange-500 flex items-center justify-center">
              <svg class="w-5 h-5 text-white" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M12 2v4m0 12v4M4.93 4.93l2.83 2.83m8.48 8.48 2.83 2.83M2 12h4m12 0h4M4.93 19.07l2.83-2.83m8.48-8.48 2.83-2.83"/></svg>
            </div>
            <div>
              <p class="text-xs text-slate-400">Tiempo promedio</p>
              <p class="text-sm font-bold text-white">2h 15min</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- ============ STATS ============ -->
  <section class="bg-slate-900 text-white py-16">
    <div class="max-w-7xl mx-auto px-6 lg:px-8 grid grid-cols-2 lg:grid-cols-4 gap-8">
      <div class="text-center lg:text-left">
        <p class="text-4xl lg:text-5xl font-bold bg-gradient-to-r from-orange-400 to-rose-400 bg-clip-text text-transparent">+50K</p>
        <p class="text-slate-400 mt-2 text-sm">Paquetes entregados</p>
      </div>
      <div class="text-center lg:text-left">
        <p class="text-4xl lg:text-5xl font-bold bg-gradient-to-r from-orange-400 to-rose-400 bg-clip-text text-transparent">98.7%</p>
        <p class="text-slate-400 mt-2 text-sm">Entregas a tiempo</p>
      </div>
      <div class="text-center lg:text-left">
        <p class="text-4xl lg:text-5xl font-bold bg-gradient-to-r from-orange-400 to-rose-400 bg-clip-text text-transparent">120+</p>
        <p class="text-slate-400 mt-2 text-sm">Motorizados activos</p>
      </div>
      <div class="text-center lg:text-left">
        <p class="text-4xl lg:text-5xl font-bold bg-gradient-to-r from-orange-400 to-rose-400 bg-clip-text text-transparent">24/7</p>
        <p class="text-slate-400 mt-2 text-sm">Cobertura disponible</p>
      </div>
    </div>
  </section>

  <!-- ============ SERVICIOS ============ -->
  <section id="servicios" class="py-24 bg-slate-50">
    <div class="max-w-7xl mx-auto px-6 lg:px-8">
      <div class="text-center max-w-2xl mx-auto mb-16">
        <span class="inline-block px-3 py-1 rounded-full bg-orange-100 text-orange-700 text-xs font-semibold mb-4">NUESTROS SERVICIOS</span>
        <h2 class="text-4xl lg:text-5xl font-bold tracking-tight">Elige cómo quieres enviar</h2>
        <p class="mt-4 text-slate-600 text-lg">Dos modalidades diseñadas para adaptarse a tu ritmo y al de tu destinatario.</p>
      </div>

      <div class="grid md:grid-cols-2 gap-6">
        <!-- Servicio 1 -->
        <div class="group relative bg-white rounded-3xl p-8 border border-slate-200 hover:border-orange-300 hover:shadow-2xl hover:shadow-orange-500/10 transition-all overflow-hidden">
          <div class="absolute -top-16 -right-16 w-48 h-48 rounded-full bg-orange-100 group-hover:bg-orange-200 transition"></div>
          <div class="relative">
            <div class="w-14 h-14 rounded-2xl bg-gradient-to-br from-orange-500 to-rose-500 flex items-center justify-center text-white shadow-lg shadow-orange-500/30 mb-6">
              <svg class="w-7 h-7" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M3 9 12 2l9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"/><path d="M9 22V12h6v10"/></svg>
            </div>
            <h3 class="text-2xl font-bold">Domicilio a Domicilio</h3>
            <p class="mt-3 text-slate-600 leading-relaxed">Recogemos tu paquete donde estés y lo entregamos en la puerta del destinatario. Tú no te mueves, nosotros hacemos todo.</p>

            <ul class="mt-6 space-y-3 text-sm text-slate-700">
              <li class="flex items-center gap-3"><svg class="w-5 h-5 text-emerald-500" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M20 6 9 17l-5-5"/></svg>Recojo inmediato con motorizado</li>
              <li class="flex items-center gap-3"><svg class="w-5 h-5 text-emerald-500" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M20 6 9 17l-5-5"/></svg>Entrega directa al destino</li>
              <li class="flex items-center gap-3"><svg class="w-5 h-5 text-emerald-500" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M20 6 9 17l-5-5"/></svg>Notificaciones en cada etapa</li>
            </ul>

            <a href="#registrar" class="mt-8 inline-flex items-center gap-2 text-orange-600 font-semibold hover:gap-3 transition-all">
              Enviar ahora
              <svg class="w-4 h-4" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M5 12h14m-6-6 6 6-6 6"/></svg>
            </a>
          </div>
        </div>

        <!-- Servicio 2 -->
        <div class="group relative bg-white rounded-3xl p-8 border border-slate-200 hover:border-indigo-300 hover:shadow-2xl hover:shadow-indigo-500/10 transition-all overflow-hidden">
          <div class="absolute -top-16 -right-16 w-48 h-48 rounded-full bg-indigo-100 group-hover:bg-indigo-200 transition"></div>
          <div class="relative">
            <div class="w-14 h-14 rounded-2xl bg-gradient-to-br from-indigo-500 to-violet-600 flex items-center justify-center text-white shadow-lg shadow-indigo-500/30 mb-6">
              <svg class="w-7 h-7" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M3 21h18M3 10h18M5 6l7-3 7 3M4 10v11m16-11v11M8 14v3m4-3v3m4-3v3"/></svg>
            </div>
            <h3 class="text-2xl font-bold">Recojo en Agencia</h3>
            <p class="mt-3 text-slate-600 leading-relaxed">El destinatario recoge el paquete en la agencia más cercana, a su hora, sin esperas. Perfecto para quienes no están en casa.</p>

            <ul class="mt-6 space-y-3 text-sm text-slate-700">
              <li class="flex items-center gap-3"><svg class="w-5 h-5 text-emerald-500" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M20 6 9 17l-5-5"/></svg>Red de agencias en toda la ciudad</li>
              <li class="flex items-center gap-3"><svg class="w-5 h-5 text-emerald-500" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M20 6 9 17l-5-5"/></svg>Tarifa reducida</li>
              <li class="flex items-center gap-3"><svg class="w-5 h-5 text-emerald-500" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M20 6 9 17l-5-5"/></svg>Horario extendido de retiro</li>
            </ul>

            <a href="#registrar" class="mt-8 inline-flex items-center gap-2 text-indigo-600 font-semibold hover:gap-3 transition-all">
              Ver agencias
              <svg class="w-4 h-4" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M5 12h14m-6-6 6 6-6 6"/></svg>
            </a>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- ============ PROCESO / CÓMO FUNCIONA ============ -->
  <section id="proceso" class="py-24 bg-white">
    <div class="max-w-7xl mx-auto px-6 lg:px-8">
      <div class="text-center max-w-2xl mx-auto mb-16">
        <span class="inline-block px-3 py-1 rounded-full bg-orange-100 text-orange-700 text-xs font-semibold mb-4">CÓMO FUNCIONA</span>
        <h2 class="text-4xl lg:text-5xl font-bold tracking-tight">4 pasos. Cero complicaciones.</h2>
        <p class="mt-4 text-slate-600 text-lg">Desde que registras tu paquete hasta que llega a destino, tú solo disfrutas de la tranquilidad.</p>
      </div>

      <div class="relative grid md:grid-cols-2 lg:grid-cols-4 gap-6">
        <!-- Connecting line (desktop) -->
        <div class="hidden lg:block absolute top-12 left-[12.5%] right-[12.5%] h-0.5 bg-gradient-to-r from-orange-300 via-rose-300 to-indigo-300"></div>

        <!-- Paso 1 -->
        <div class="relative bg-white rounded-2xl p-6 border border-slate-100 hover:shadow-xl transition-all">
          <div class="relative z-10 w-14 h-14 rounded-2xl bg-white border-2 border-orange-500 text-orange-500 flex items-center justify-center mb-5 shadow-lg shadow-orange-500/20">
            <svg class="w-6 h-6" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"/><path d="M14 2v6h6M12 18v-6m-3 3h6"/></svg>
          </div>
          <span class="text-xs font-bold text-orange-500">PASO 01</span>
          <h3 class="mt-2 text-xl font-bold">Registra tu paquete</h3>
          <p class="mt-2 text-slate-600 text-sm leading-relaxed">Ingresa los datos, dimensiones y direcciones desde la app o la web. En menos de 1 minuto.</p>
        </div>

        <!-- Paso 2 -->
        <div class="relative bg-white rounded-2xl p-6 border border-slate-100 hover:shadow-xl transition-all">
          <div class="relative z-10 w-14 h-14 rounded-2xl bg-white border-2 border-rose-500 text-rose-500 flex items-center justify-center mb-5 shadow-lg shadow-rose-500/20">
            <svg class="w-6 h-6" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M20 6 9 17l-5-5"/></svg>
          </div>
          <span class="text-xs font-bold text-rose-500">PASO 02</span>
          <h3 class="mt-2 text-xl font-bold">Confirmamos y recogemos</h3>
          <p class="mt-2 text-slate-600 text-sm leading-relaxed">Nuestro equipo valida el pedido y despacha al motorizado más cercano para recoger el paquete.</p>
        </div>

        <!-- Paso 3 -->
        <div class="relative bg-white rounded-2xl p-6 border border-slate-100 hover:shadow-xl transition-all">
          <div class="relative z-10 w-14 h-14 rounded-2xl bg-white border-2 border-violet-500 text-violet-500 flex items-center justify-center mb-5 shadow-lg shadow-violet-500/20">
            <svg class="w-6 h-6" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M3 9 12 2l9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"/><path d="M9 22V12h6v10"/></svg>
          </div>
          <span class="text-xs font-bold text-violet-500">PASO 03</span>
          <h3 class="mt-2 text-xl font-bold">Procesamos en almacén</h3>
          <p class="mt-2 text-slate-600 text-sm leading-relaxed">El paquete llega a nuestro almacén central donde se clasifica y prepara su ruta de entrega.</p>
        </div>

        <!-- Paso 4 -->
        <div class="relative bg-white rounded-2xl p-6 border border-slate-100 hover:shadow-xl transition-all">
          <div class="relative z-10 w-14 h-14 rounded-2xl bg-white border-2 border-indigo-500 text-indigo-500 flex items-center justify-center mb-5 shadow-lg shadow-indigo-500/20">
            <svg class="w-6 h-6" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M12 21s-8-4.5-8-11.8A8 8 0 0 1 12 2a8 8 0 0 1 8 7.2c0 7.3-8 11.8-8 11.8z"/><circle cx="12" cy="10" r="3"/></svg>
          </div>
          <span class="text-xs font-bold text-indigo-500">PASO 04</span>
          <h3 class="mt-2 text-xl font-bold">Entrega al destino</h3>
          <p class="mt-2 text-slate-600 text-sm leading-relaxed">Asignamos un motorizado para entrega a domicilio o lo dejamos disponible en agencia para retiro.</p>
        </div>
      </div>
    </div>
  </section>

  <!-- ============ BENEFICIOS ============ -->
  <section id="beneficios" class="py-24 bg-gradient-to-b from-slate-50 to-white">
    <div class="max-w-7xl mx-auto px-6 lg:px-8">
      <div class="grid lg:grid-cols-2 gap-16 items-center">
        <div>
          <span class="inline-block px-3 py-1 rounded-full bg-orange-100 text-orange-700 text-xs font-semibold mb-4">POR QUÉ VELOZEXPRESS</span>
          <h2 class="text-4xl lg:text-5xl font-bold tracking-tight">Diseñado para quienes no tienen tiempo que perder.</h2>
          <p class="mt-4 text-slate-600 text-lg leading-relaxed">Tecnología, motorizados capacitados y un proceso pensado para que tu envío no sea un problema más en tu día.</p>

          <div class="mt-10 space-y-6">
            <div class="flex items-start gap-4">
              <div class="w-11 h-11 rounded-xl bg-orange-100 text-orange-600 flex items-center justify-center shrink-0">
                <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><polyline points="13 2 3 14 12 14 11 22 21 10 12 10 13 2"/></svg>
              </div>
              <div>
                <h4 class="font-bold text-lg">Rapidez comprobada</h4>
                <p class="text-slate-600 text-sm mt-1">Tiempo promedio de entrega: 2 horas dentro de la ciudad.</p>
              </div>
            </div>

            <div class="flex items-start gap-4">
              <div class="w-11 h-11 rounded-xl bg-emerald-100 text-emerald-600 flex items-center justify-center shrink-0">
                <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M12 22s8-4 8-10V5l-8-3-8 3v7c0 6 8 10 8 10z"/></svg>
              </div>
              <div>
                <h4 class="font-bold text-lg">Seguridad total</h4>
                <p class="text-slate-600 text-sm mt-1">Seguro incluido y cadena de custodia trazable en todo momento.</p>
              </div>
            </div>

            <div class="flex items-start gap-4">
              <div class="w-11 h-11 rounded-xl bg-indigo-100 text-indigo-600 flex items-center justify-center shrink-0">
                <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><rect x="2" y="3" width="20" height="14" rx="2"/><line x1="8" y1="21" x2="16" y2="21"/><line x1="12" y1="17" x2="12" y2="21"/></svg>
              </div>
              <div>
                <h4 class="font-bold text-lg">Rastreo en vivo</h4>
                <p class="text-slate-600 text-sm mt-1">Mira dónde está tu paquete en tiempo real, desde el registro hasta la entrega.</p>
              </div>
            </div>

            <div class="flex items-start gap-4">
              <div class="w-11 h-11 rounded-xl bg-rose-100 text-rose-600 flex items-center justify-center shrink-0">
                <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M20.84 4.61a5.5 5.5 0 0 0-7.78 0L12 5.67l-1.06-1.06a5.5 5.5 0 0 0-7.78 7.78l1.06 1.06L12 21.23l7.78-7.78 1.06-1.06a5.5 5.5 0 0 0 0-7.78z"/></svg>
              </div>
              <div>
                <h4 class="font-bold text-lg">Atención humana</h4>
                <p class="text-slate-600 text-sm mt-1">Soporte real, sin bots frustrantes. Resolvemos lo que necesites.</p>
              </div>
            </div>
          </div>
        </div>

        <!-- Visual side: map-like card -->
        <div class="relative">
          <div class="relative bg-gradient-to-br from-slate-900 via-slate-800 to-slate-900 rounded-3xl p-8 shadow-2xl shadow-slate-900/30 overflow-hidden">
            <!-- Grid background -->
            <div class="absolute inset-0 opacity-20" style="background-image: linear-gradient(rgba(255,255,255,0.1) 1px, transparent 1px), linear-gradient(90deg, rgba(255,255,255,0.1) 1px, transparent 1px); background-size: 32px 32px;"></div>

            <!-- Routes -->
            <svg class="absolute inset-0 w-full h-full" viewBox="0 0 400 400" preserveAspectRatio="none">
              <path d="M40 340 Q 120 200 200 220 T 360 80" stroke="url(#g1)" stroke-width="2" fill="none" stroke-dasharray="6 6" class="animate-pulse"/>
              <defs>
                <linearGradient id="g1" x1="0" x2="1">
                  <stop offset="0" stop-color="#f97316"/>
                  <stop offset="1" stop-color="#f43f5e"/>
                </linearGradient>
              </defs>
            </svg>

            <div class="relative z-10 space-y-6">
              <!-- Pin 1 -->
              <div class="flex items-center gap-3 bg-white/10 backdrop-blur rounded-xl p-3 w-fit border border-white/10">
                <div class="w-10 h-10 rounded-full bg-orange-500 flex items-center justify-center">
                  <svg class="w-5 h-5 text-white" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M3 9 12 2l9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"/></svg>
                </div>
                <div>
                  <p class="text-xs text-slate-400">Origen</p>
                  <p class="text-white font-semibold text-sm">Av. Principal 123</p>
                </div>
              </div>

              <!-- Pin mid -->
              <div class="flex items-center gap-3 bg-white/10 backdrop-blur rounded-xl p-3 w-fit border border-white/10 ml-16">
                <div class="w-10 h-10 rounded-full bg-violet-500 flex items-center justify-center">
                  <svg class="w-5 h-5 text-white" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M21 8V4H3v4M21 8l-9 6-9-6M21 8v12H3V8"/></svg>
                </div>
                <div>
                  <p class="text-xs text-slate-400">Almacén central</p>
                  <p class="text-white font-semibold text-sm">Clasificación</p>
                </div>
              </div>

              <!-- Pin 2 -->
              <div class="flex items-center gap-3 bg-white/10 backdrop-blur rounded-xl p-3 w-fit border border-white/10 ml-auto">
                <div class="w-10 h-10 rounded-full bg-emerald-500 flex items-center justify-center relative">
                  <svg class="w-5 h-5 text-white" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M20 6 9 17l-5-5"/></svg>
                  <span class="absolute -top-1 -right-1 flex h-3 w-3"><span class="animate-ping absolute inline-flex h-full w-full rounded-full bg-emerald-400 opacity-75"></span><span class="relative inline-flex rounded-full h-3 w-3 bg-emerald-500"></span></span>
                </div>
                <div>
                  <p class="text-xs text-slate-400">Destino</p>
                  <p class="text-white font-semibold text-sm">Entregado</p>
                </div>
              </div>
            </div>

            <div class="relative mt-8 pt-6 border-t border-white/10 flex items-center justify-between">
              <div>
                <p class="text-xs text-slate-400">Ruta optimizada</p>
                <p class="text-white font-bold">8.4 km · 23 min</p>
              </div>
              <div class="flex items-center gap-1 text-emerald-400 text-sm font-semibold">
                <svg class="w-4 h-4" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><polyline points="23 6 13.5 15.5 8.5 10.5 1 18"/><polyline points="17 6 23 6 23 12"/></svg>
                15% más rápido
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- ============ TESTIMONIOS ============ -->
  <section class="py-24 bg-white">
    <div class="max-w-7xl mx-auto px-6 lg:px-8">
      <div class="text-center max-w-2xl mx-auto mb-16">
        <span class="inline-block px-3 py-1 rounded-full bg-orange-100 text-orange-700 text-xs font-semibold mb-4">TESTIMONIOS</span>
        <h2 class="text-4xl lg:text-5xl font-bold tracking-tight">Lo que dicen nuestros clientes</h2>
      </div>

      <div class="grid md:grid-cols-3 gap-6">
        <div class="bg-slate-50 rounded-3xl p-8 border border-slate-100">
          <div class="flex items-center gap-1 text-amber-500 mb-4">
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
          </div>
          <p class="text-slate-700 leading-relaxed">"Mi tienda online despegó desde que uso VelozExpress. Los clientes reciben sus pedidos el mismo día y eso vende por sí solo."</p>
          <div class="mt-6 flex items-center gap-3">
            <div class="w-11 h-11 rounded-full bg-gradient-to-br from-orange-400 to-rose-500 flex items-center justify-center text-white font-bold">MR</div>
            <div>
              <p class="font-semibold text-sm">María Rodríguez</p>
              <p class="text-xs text-slate-500">Dueña de tienda online</p>
            </div>
          </div>
        </div>

        <div class="bg-slate-900 text-white rounded-3xl p-8 lg:-translate-y-4 shadow-2xl shadow-slate-900/20">
          <div class="flex items-center gap-1 text-amber-400 mb-4">
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
          </div>
          <p class="leading-relaxed">"Envío documentos todos los días y nunca he tenido un retraso. El rastreo en vivo me da mucha tranquilidad, sobre todo con entregas urgentes."</p>
          <div class="mt-6 flex items-center gap-3">
            <div class="w-11 h-11 rounded-full bg-gradient-to-br from-indigo-400 to-violet-600 flex items-center justify-center text-white font-bold">JP</div>
            <div>
              <p class="font-semibold text-sm">Juan Pérez</p>
              <p class="text-xs text-slate-400">Gerente de logística</p>
            </div>
          </div>
        </div>

        <div class="bg-slate-50 rounded-3xl p-8 border border-slate-100">
          <div class="flex items-center gap-1 text-amber-500 mb-4">
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
            <svg class="w-4 h-4 fill-current" viewBox="0 0 24 24"><path d="m12 17.27 6.18 3.73-1.64-7.03L22 9.24l-7.19-.62L12 2 9.19 8.62 2 9.24l5.46 4.73L5.82 21z"/></svg>
          </div>
          <p class="text-slate-700 leading-relaxed">"La opción de recojo en agencia me salvó la vida. Trabajo todo el día fuera y puedo pasar cuando me quede cómodo. 10/10."</p>
          <div class="mt-6 flex items-center gap-3">
            <div class="w-11 h-11 rounded-full bg-gradient-to-br from-emerald-400 to-teal-500 flex items-center justify-center text-white font-bold">LS</div>
            <div>
              <p class="font-semibold text-sm">Lucía Salas</p>
              <p class="text-xs text-slate-500">Freelancer</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- ============ CTA FINAL ============ -->
  <section id="registrar" class="py-24 bg-white">
    <div class="max-w-6xl mx-auto px-6 lg:px-8">
      <div class="relative overflow-hidden rounded-[2.5rem] bg-gradient-to-br from-slate-900 via-slate-800 to-slate-900 p-10 lg:p-16">
        <!-- Decorative -->
        <div class="absolute -top-20 -right-20 w-80 h-80 rounded-full bg-orange-500/20 blur-3xl"></div>
        <div class="absolute -bottom-20 -left-20 w-80 h-80 rounded-full bg-rose-500/20 blur-3xl"></div>

        <div class="relative grid lg:grid-cols-2 gap-10 items-center">
          <div>
            <span class="inline-block px-3 py-1 rounded-full bg-white/10 text-white text-xs font-semibold mb-4 backdrop-blur">¿LISTO PARA ENVIAR?</span>
            <h2 class="text-4xl lg:text-5xl font-bold text-white tracking-tight">Tu primer envío es en <span class="bg-gradient-to-r from-orange-400 to-rose-400 bg-clip-text text-transparent">2 clics</span>.</h2>
            <p class="mt-4 text-slate-300 text-lg">Registra tu paquete ahora, nosotros nos encargamos del resto. Sin contratos, sin letra chica.</p>

            <div class="mt-8 flex flex-wrap gap-3">
              <a href="#" class="inline-flex items-center gap-2 px-6 py-3.5 rounded-full bg-white text-slate-900 font-semibold hover:bg-slate-100 transition shadow-xl">
                Registrar paquete
                <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M5 12h14m-6-6 6 6-6 6"/></svg>
              </a>
              <a href="#" class="inline-flex items-center gap-2 px-6 py-3.5 rounded-full bg-white/10 border border-white/20 text-white font-semibold backdrop-blur hover:bg-white/20 transition">
                Hablar con ventas
              </a>
            </div>
          </div>

          <!-- Quick form -->
          <div class="bg-white rounded-2xl p-6 shadow-2xl">
            <p class="text-sm font-semibold text-slate-900 mb-4">Cotiza tu envío en segundos</p>
            <div class="space-y-3">
              <div class="relative">
                <svg class="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 text-orange-500" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><circle cx="12" cy="12" r="4"/></svg>
                <input type="text" placeholder="Dirección de recojo" class="w-full pl-11 pr-4 py-3 rounded-xl bg-slate-50 border border-slate-200 text-sm focus:outline-none focus:border-orange-500 focus:bg-white transition"/>
              </div>
              <div class="relative">
                <svg class="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 text-rose-500" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M12 21s-8-4.5-8-11.8A8 8 0 0 1 12 2a8 8 0 0 1 8 7.2c0 7.3-8 11.8-8 11.8z"/></svg>
                <input type="text" placeholder="Dirección de destino" class="w-full pl-11 pr-4 py-3 rounded-xl bg-slate-50 border border-slate-200 text-sm focus:outline-none focus:border-orange-500 focus:bg-white transition"/>
              </div>
              <div class="grid grid-cols-2 gap-3">
                <select class="w-full px-4 py-3 rounded-xl bg-slate-50 border border-slate-200 text-sm text-slate-700 focus:outline-none focus:border-orange-500 focus:bg-white transition">
                  <option>Tamaño pequeño</option>
                  <option>Tamaño mediano</option>
                  <option>Tamaño grande</option>
                </select>
                <select class="w-full px-4 py-3 rounded-xl bg-slate-50 border border-slate-200 text-sm text-slate-700 focus:outline-none focus:border-orange-500 focus:bg-white transition">
                  <option>A domicilio</option>
                  <option>Recojo en agencia</option>
                </select>
              </div>
              <button class="w-full py-3.5 rounded-xl bg-gradient-to-r from-orange-500 to-rose-500 text-white font-semibold hover:shadow-lg hover:shadow-orange-500/40 transition">
                Cotizar ahora
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- ============ FOOTER ============ -->
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

</div>

<style>
  @keyframes float {
    0%, 100% { transform: translateY(0); }
    50% { transform: translateY(-10px); }
  }
  html { scroll-behavior: smooth; }
</style>

<!-- <router-outlet /> -->

  `,
})
export default class WebsiteHome {}
