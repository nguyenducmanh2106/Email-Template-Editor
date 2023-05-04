"use strict";
(self.webpackChunkunlayer = self.webpackChunkunlayer || []).push([[688], {
    88343: function(e, t, n) {
        n.r(t);
        var r, o = n(27378), a = n(80715), l = n(83573), i = n(73355), c = n(8441), u = n(60042), s = n.n(u), f = n(29902), d = n(97762), m = n(76136), g = n(38549);
        function y(e) {
            return function(e) {
                if (Array.isArray(e))
                    return v(e)
            }(e) || function(e) {
                if ("undefined" != typeof Symbol && null != e[Symbol.iterator] || null != e["@@iterator"])
                    return Array.from(e)
            }(e) || p(e) || function() {
                throw new TypeError("Invalid attempt to spread non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.")
            }()
        }
        function p(e, t) {
            if (e) {
                if ("string" == typeof e)
                    return v(e, t);
                var n = Object.prototype.toString.call(e).slice(8, -1);
                return "Object" === n && e.constructor && (n = e.constructor.name),
                "Map" === n || "Set" === n ? Array.from(e) : "Arguments" === n || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n) ? v(e, t) : void 0
            }
        }
        function v(e, t) {
            (null == t || t > e.length) && (t = e.length);
            for (var n = 0, r = new Array(t); n < t; n++)
                r[n] = e[n];
            return r
        }
        var b = o.lazy((function() {
            return n.e(539).then(n.bind(n, 29446))
        }
        ))
          , h = o.memo((function(e) {
            var t, n, r = e.children, c = e.type, u = e.contentVersion, v = e.mergeTagGroup, h = e.mergeTagRule, C = e.fullScreen, w = void 0 !== C && C, T = e.displayMode, A = e.inline, E = e.fixedToolbarContainer, x = e.autoFocus, k = e.trackKeystrokes, j = e.onSettings, M = e.onInit, I = e.onFormatContent, L = e.onChange, F = (t = (0,
            o.useState)(!1),
            n = 2,
            function(e) {
                if (Array.isArray(e))
                    return e
            }(t) || function(e, t) {
                var n = null == e ? null : "undefined" != typeof Symbol && e[Symbol.iterator] || e["@@iterator"];
                if (null != n) {
                    var r, o, a = [], l = !0, i = !1;
                    try {
                        for (n = n.call(e); !(l = (r = n.next()).done) && (a.push(r.value),
                        !t || a.length !== t); l = !0)
                            ;
                    } catch (e) {
                        i = !0,
                        o = e
                    } finally {
                        try {
                            l || null == n.return || n.return()
                        } finally {
                            if (i)
                                throw o
                        }
                    }
                    return a
                }
            }(t, n) || p(t, n) || function() {
                throw new TypeError("Invalid attempt to destructure non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.")
            }()), O = F[0], R = F[1], N = (0,
            g.Z)(), Z = (0,
            a.I0)(), _ = (0,
            a.v9)(f.wl.allowCustomFonts), z = (0,
            a.v9)(f.wl.getAppearance), D = (0,
            a.v9)(f.wl.getLocale), q = (0,
            a.v9)(f.wl.getTextDirection), B = (0,
            a.v9)(f.wl.getMergeTags), G = (0,
            a.v9)(f.wl.getMergeTagsConfig), H = (0,
            a.v9)(f.wl.getColors), K = (0,
            a.v9)(f.wl.getSyncVersion), P = (0,
            a.v9)(f.wl.getEntitlements), U = (0,
            l.Z)(), V = (0,
            o.useRef)(null), W = (0,
            o.useRef)(void 0), X = (0,
            o.useRef)(), $ = (0,
            m.p)(L);
            function J(e) {
                if ($.current) {
                    null == I || I(e);
                    var t = (0,
                    d.L5)(e);
                    t !== X.current && ($.current(t, e),
                    X.current = t)
                }
            }
            var Q = N.hasCallback("mergeTag")
              , Y = (0,
            o.useCallback)((function() {
                R(!0)
            }
            ), []);
            (0,
            o.useEffect)((function() {
                var e = {};
                (0,
                d.j_)(e, {
                    type: c,
                    fullScreen: w
                }),
                (0,
                d.Kj)(e, {
                    recentColors: H
                }),
                (0,
                d.b4)(e, {
                    type: c,
                    fullScreen: w,
                    displayMode: T,
                    textDirection: q
                }),
                (0,
                d.bl)(e, {
                    fullScreen: w,
                    displayMode: T
                }),
                (0,
                d.Ze)(e),
                (0,
                d.ZX)(e, {
                    type: c,
                    mergeTags: B,
                    mergeTagGroup: v,
                    mergeTagRule: h,
                    mergeTagsConfig: G,
                    hasMergeTagCallback: Q,
                    intl: U
                }),
                (0,
                d.hR)(e, {
                    allowCustomFonts: _
                }),
                (0,
                d.vf)(e, {
                    locale: D
                }),
                (0,
                d.al)(e, {
                    textDirection: q
                }),
                (0,
                d.eE)(e, {
                    appearance: z
                }),
                (0,
                d.hG)(e, {
                    type: c,
                    intl: U,
                    entitlements: P,
                    onAction: Y
                }),
                j && j(e);
                var t = V.current.querySelector(".editable") || V.current;
                A && (e.inline = !0),
                E && (e.fixed_toolbar_container = E),
                e.init_instance_callback = function(e) {
                    var t;
                    x && e.focus(!1),
                    M && M(e),
                    null === (t = V.current) || void 0 === t || t.classList.add("loaded")
                }
                ,
                e.setup = function(t) {
                    var n = ["blur", "change", "focusout"];
                    t.on("BeforeExecCommand", (function(e) {
                        -1 !== ["mceToggleFormat", "mceApplyTextcolor", "mceRemoveTextcolor", "FontName", "FontSize", "mceInsertLink"].indexOf(e.command) && y(t.getBody().querySelectorAll(".mceNonEditable")).map((function(e) {
                            e.setAttribute("contenteditable", null)
                        }
                        ))
                    }
                    )),
                    t.on("ExecCommand", (function(e) {
                        y(t.getBody().querySelectorAll(".mceNonEditable")).map((function(e) {
                            e.setAttribute("contenteditable", !1)
                        }
                        ))
                    }
                    )),
                    k && n.push("keyup"),
                    t.on(n.join(" "), (function() {
                        J(t)
                    }
                    )),
                    t.on("click", (function(e) {
                        e.target.outerHTML.startsWith("<code") && e.target.outerHTML.includes('data-type="merge-tag"') && t.selection.select(e.target)
                    }
                    )),
                    t.on("TextColorChange", (function(t) {
                        var n = "".concat((null == t ? void 0 : t.color) || "").trim().toLowerCase();
                        n && ((e.color_map || []).some((function(e, t) {
                            return t % 2 == 0 && !(n !== "".concat(e || "").trim().toLowerCase())
                        }
                        )) || setTimeout((function() {
                            Z(f.Nw.saveColor(n))
                        }
                        ), 100))
                    }
                    ))
                }
                ,
                W.current && W.current.remove();
                var n = f.h.getState()
                  , r = f.wl.getCurrentSelection(n)
                  , o = f.wl.getDesignUI(n);
                (null != r && r.active || "classic" === o) && (W.current = i.Z.EditorManager.createEditor(t, e),
                W.current.render())
            }
            ), [Q, v, h, H]),
            (0,
            o.useEffect)((function() {
                return function() {
                    W.current && (J(W.current),
                    W.current.destroy())
                }
            }
            ), []),
            (0,
            o.useLayoutEffect)((function() {
                W.current && J(W.current)
            }
            ), [K, u]);
            var ee = e.id
              , te = e.className
              , ne = e.style;
            return o.createElement(o.Fragment, null, o.createElement(S.Container, {
                id: ee,
                className: s()("content-editor-container", te),
                style: ne,
                ref: V
            }, r), O && o.createElement(b, {
                isOpened: O,
                editor: null == W ? void 0 : W.current,
                onClose: function() {
                    return R(!1)
                }
            }))
        }
        ));
        t.default = h;
        var C, w, S = {
            Container: c.ZP.div(r || (C = ["\n    a {\n      pointer-events: none !important;\n\n      code[data-type='merge-tag'] {\n        pointer-events: all !important;\n      }\n    }\n\n    &.disabled-inline-controls {\n      .tox-toolbar:first-child > :last-child {\n        justify-content: flex-start !important;\n      }\n    }\n  "],
            w || (w = C.slice(0)),
            r = Object.freeze(Object.defineProperties(C, {
                raw: {
                    value: Object.freeze(w)
                }
            }))))
        }
    }
}]);
