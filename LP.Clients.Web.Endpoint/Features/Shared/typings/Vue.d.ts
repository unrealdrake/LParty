declare var Vue: IVue;

type Constructor = {
  new (...args: any[]): any;
}

interface ComponentOptions<V extends IVue> {
  data?: Object | ((this: V) => Object);
  props?: string[] | { [key: string]: PropOptions | Constructor | Constructor[] };
  propsData?: Object;
  computed?: { [key: string]: ((this: V) => any) | ComputedOptions<V> };
  methods?: { [key: string]: (this: V, ...args: any[]) => any };
  watch?: { [key: string]: ({ handler: WatchHandler<V, any> } & WatchOptions) | WatchHandler<V, any> | string };

  el?: Element | String;
  template?: string;
  render?(this: V, createElement: CreateElement): VNode;
  renderError?: (h: () => VNode, err: Error) => VNode;
  staticRenderFns?: ((createElement: CreateElement) => VNode)[];

  beforeCreate?(this: V): void;
  created?(this: V): void;
  beforeDestroy?(this: V): void;
  destroyed?(this: V): void;
  beforeMount?(this: V): void;
  mounted?(this: V): void;
  beforeUpdate?(this: V): void;
  updated?(this: V): void;
  activated?(this: V): void;
  deactivated?(this: V): void;

  directives?: { [key: string]: DirectiveOptions | DirectiveFunction };
  components?: { [key: string]: Component | AsyncComponent };
  transitions?: { [key: string]: Object };
  filters?: { [key: string]: Function };

  provide?: Object | (() => Object);
  inject?: { [key: string]: string | symbol } | Array<string>;

  model?: {
    prop?: string;
    event?: string;
  };

  parent?: IVue;
  mixins?: (ComponentOptions<IVue> | any)[];
  name?: string;
  extends?: ComponentOptions<IVue> | any;
  delimiters?: [string, string];
  comments?: boolean;
  inheritAttrs?: boolean;
}

type ScopedSlot = (props: any) => VNodeChildrenArrayContents | string;

type VNodeChildren = VNodeChildrenArrayContents | [ScopedSlot] | string;
interface VNodeChildrenArrayContents {
  [x: number]: VNode | string | VNodeChildren;
}

interface VNode {
  tag?: string;
  data?: VNodeData;
  children?: VNode[];
  text?: string;
  elm?: Node;
  ns?: string;
  context?: IVue;
  key?: string | number;
  componentOptions?: VNodeComponentOptions;
  componentInstance?: IVue;
  parent?: VNode;
  raw?: boolean;
  isStatic?: boolean;
  isRootInsert: boolean;
  isComment: boolean;
}

interface VNodeComponentOptions {
  Ctor: typeof Vue;
  propsData?: Object;
  listeners?: Object;
  children?: VNodeChildren;
  tag?: string;
}

interface VNodeData {
  key?: string | number;
  slot?: string;
  scopedSlots?: { [key: string]: ScopedSlot };
  ref?: string;
  tag?: string;
  staticClass?: string;
  class?: any;
  staticStyle?: { [key: string]: any };
  style?: Object[] | Object;
  props?: { [key: string]: any };
  attrs?: { [key: string]: any };
  domProps?: { [key: string]: any };
  hook?: { [key: string]: Function };
  on?: { [key: string]: Function | Function[] };
  nativeOn?: { [key: string]: Function | Function[] };
  transition?: Object;
  show?: boolean;
  inlineTemplate?: {
    render: Function;
    staticRenderFns: Function[];
  };
  directives?: VNodeDirective[];
  keepAlive?: boolean;
}

interface VNodeDirective {
  readonly name: string;
  readonly value: any;
  readonly oldValue: any;
  readonly expression: any;
  readonly arg: string;
  readonly modifiers: { [key: string]: boolean };
}

type CreateElement = {
  // empty node
  (): VNode;

  // element or component name
  (tag: string, children: VNodeChildren): VNode;
  (tag: string, data?: VNodeData, children?: VNodeChildren): VNode;

  // component constructor or options
  (tag: Component, children: VNodeChildren): VNode;
  (tag: Component, data?: VNodeData, children?: VNodeChildren): VNode;

  // async component
  (tag: AsyncComponent, children: VNodeChildren): VNode;
  (tag: AsyncComponent, data?: VNodeData, children?: VNodeChildren): VNode;
}

interface IVue {
 
  constructor(options?: ComponentOptions<IVue>);
  new (options?: ComponentOptions<IVue>): IVue;
  $data: Object;
  readonly $el: HTMLElement;
  readonly $options: ComponentOptions<this>;
  readonly $parent: IVue;
  readonly $root: IVue;
  readonly $children: IVue[];
  readonly $refs: { [key: string]: IVue | Element | IVue[] | Element[]};
  readonly $slots: { [key: string]: VNode[] };
  readonly $scopedSlots: { [key: string]: ScopedSlot };
  readonly $isServer: boolean;
  readonly $ssrContext: any;
  readonly $props: any;
  readonly $vnode: VNode;
  readonly $attrs: { [key: string] : string };
  readonly $listeners: { [key: string]: Function | Array<Function> };

  $mount(elementOrSelector?: Element | String, hydrating?: boolean): this;
  $forceUpdate(): void;
  $destroy(): void;
  $set: typeof Vue.set;
  $delete: typeof Vue.delete;
  $watch(
    expOrFn: string,
    callback: WatchHandler<this, any>,
    options?: WatchOptions
  ): (() => void);
  $watch<T>(
    expOrFn: (this: this) => T,
    callback: WatchHandler<this, T>,
    options?: WatchOptions
  ): (() => void);
  $on(event: string | string[], callback: Function): this;
  $once(event: string, callback: Function): this;
  $off(event?: string | string[], callback?: Function): this;
  $emit(event: string, ...args: any[]): this;
  $nextTick(callback: (this: this) => void): void;
  $nextTick(): Promise<void>;
  $createElement: CreateElement;

  config: {
    silent: boolean;
    optionMergeStrategies: any;
    devtools: boolean;
    productionTip: boolean;
    performance: boolean;
    errorHandler(err: Error, vm: IVue, info: string): void;
    warnHandler(msg: string, vm: IVue, trace: string): void;
    ignoredElements: string[];
    keyCodes: { [key: string]: number };
  }

  extend(options: ComponentOptions<IVue> | FunctionalComponentOptions): typeof Vue;
  nextTick(callback: () => void, context?: any[]): void;
  nextTick(): Promise<void>;
  set<T>(object: Object, key: string, value: T): T;
  set<T>(array: T[], key: number, value: T): T;
  delete(object: Object, key: string): void;
  delete<T>(array: T[], key: number): void;

  directive(
    id: string,
    definition?: DirectiveOptions | DirectiveFunction
  ): DirectiveOptions;
  filter(id: string, definition?: Function): Function;
  component(id: string, definition?: Component | AsyncComponent): typeof Vue;

  use<T>(plugin: PluginObject<T> | PluginFunction<T>, options?: T): void;
  mixin(mixin: typeof Vue | ComponentOptions<IVue>): void;
  compile(template: string): {
    render(createElement: typeof Vue.prototype.$createElement): VNode;
    staticRenderFns: (() => VNode)[];
  };
}

type PluginFunction<T> = (Vue: IVue, options?: T) => void;

interface PluginObject<T> {
  install: PluginFunction<T>;
  [key: string]: any;
}

type Component = typeof Vue | ComponentOptions<IVue> | FunctionalComponentOptions;
type AsyncComponent = (
  resolve: (component: Component) => void,
  reject: (reason?: any) => void
) => Promise<Component> | Component | void;

interface FunctionalComponentOptions {
  name?: string;
  props?: string[] | { [key: string]: PropOptions | Constructor | Constructor[] };
  functional: boolean;
  render(this: never, createElement: CreateElement, context: RenderContext): VNode | void;
}

interface RenderContext {
  props: any;
  children: VNode[];
  slots(): any;
  data: VNodeData;
  parent: IVue;
  injections: any;
}

interface PropOptions {
  type?: Constructor | Constructor[] | null;
  required?: boolean;
  default?: any;
  validator?(value: any): boolean;
}

interface ComputedOptions<V> {
  get?(this: V): any;
  set?(this: V, value: any): void;
  cache?: boolean;
}

type WatchHandler<V, T> = (this: V, val: T, oldVal: T) => void;

interface WatchOptions {
  deep?: boolean;
  immediate?: boolean;
}

type DirectiveFunction = (
  el: HTMLElement,
  binding: VNodeDirective,
  vnode: VNode,
  oldVnode: VNode
) => void;

interface DirectiveOptions {
  bind?: DirectiveFunction;
  inserted?: DirectiveFunction;
  update?: DirectiveFunction;
  componentUpdated?: DirectiveFunction;
  unbind?: DirectiveFunction;
}