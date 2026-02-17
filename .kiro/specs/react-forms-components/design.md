# Design Document: React Forms Components

## Overview

This design document specifies the implementation of a comprehensive React Forms component library that mirrors the functionality of the existing Razor/Blazor Forms implementation. The library consists of five main components: TextField, FieldGroup, FieldText, FieldAction, and FieldBadge. These components follow Yasamen design patterns, integrate with popular React form libraries (React Hook Form, Formik), and provide a complete solution for building accessible, validated form inputs.

The design emphasizes composition, allowing developers to use TextField as a high-level component or compose custom fields using FieldGroup with other components. All components are implemented as TypeScript functional components with proper type definitions and ref forwarding support.

## Architecture

### Component Hierarchy

```
TextField (High-level component)
  └─> FieldGroup (Layout wrapper)
       ├─> Label section (ya-field-group-description)
       │    ├─> Label element (ya-field-group-label)
       │    └─> Description complement (optional)
       ├─> Control section
       │    ├─> Prepend content (optional, within ya-control-group)
       │    ├─> Input element (ya-input-field)
       │    └─> Append content (optional, within ya-control-group)
       └─> Informative section (ya-field-group-informative)
            ├─> Information text (ya-field-information)
            ├─> Error message (when invalid)
            └─> Footer action (ya-field-group-footer)

FieldText (Standalone text wrapper)
FieldAction (Standalone action button)
FieldBadge (Standalone badge)
```

### Component Relationships

- **TextField** internally uses **FieldGroup** for layout
- **FieldGroup** is a generic layout component that accepts any children
- **FieldText**, **FieldAction**, and **FieldBadge** are standalone components that can be used:
  - Inside FieldGroup's prepend/append/footerAction props
  - Standalone in custom layouts
  - As children of other components

### Integration Points

1. **React Hook Form**: TextField forwards refs and spreads register props
2. **Formik**: TextField accepts field props and integrates with Formik's error handling
3. **Yasamen Button**: FieldAction wraps the existing Button component
4. **Yasamen Badge**: FieldBadge wraps the existing Badge component
5. **CSS Framework**: All components use Yasamen CSS classes and variables

## Components and Interfaces

### TextField Component

**Purpose**: High-level controlled input component with complete field layout.

**Props Interface**:
```typescript
interface TextFieldProps extends Omit<React.InputHTMLAttributes<HTMLInputElement>, 'size'> {
  // Core input props
  value?: string;
  onChange?: (event: React.ChangeEvent<HTMLInputElement>) => void;
  onBlur?: (event: React.FocusEvent<HTMLInputElement>) => void;
  type?: 'text' | 'password' | 'email' | 'number' | 'tel' | 'url';
  name?: string;
  placeholder?: string;
  disabled?: boolean;
  readOnly?: boolean;
  maxLength?: number;
  
  // Layout props
  label?: string;
  information?: string;
  error?: string | { message?: string };
  descriptionComplement?: React.ReactNode;
  prepend?: React.ReactNode;
  append?: React.ReactNode;
  footerAction?: React.ReactNode;
  
  // Styling props
  size?: 'smallest' | 'smaller' | 'small' | 'medium' | 'large' | 'larger' | 'largest';
  expanded?: boolean;
  
  // Accessibility
  id?: string;
  'aria-label'?: string;
  'aria-describedby'?: string;
}
```

**Implementation Details**:
- Uses `React.forwardRef` to forward refs to the input element
- Generates unique IDs for label association and aria-describedby
- Internally renders FieldGroup with all layout props
- Applies `ya-input-field` class to input element
- Applies `ya-input-field-invalid` class when error is present
- Applies `ya-field-{size}` class based on size prop
- Wraps input in `ya-control-group` when prepend or append is present

**State Management**:
- Controlled component (value managed by parent)
- No internal state for input value
- Generates stable IDs using useId hook (React 18+) or fallback

### FieldGroup Component

**Purpose**: Generic layout wrapper for form fields with label, control, info, and error sections.

**Props Interface**:
```typescript
interface FieldGroupProps {
  // Content sections
  label?: string;
  descriptionComplement?: React.ReactNode;
  children: React.ReactNode;
  information?: string;
  error?: string | { message?: string };
  prepend?: React.ReactNode;
  append?: React.ReactNode;
  footerAction?: React.ReactNode;
  
  // Styling props
  size?: 'smallest' | 'smaller' | 'small' | 'medium' | 'large' | 'larger' | 'largest';
  expanded?: boolean;
  invalid?: boolean;
  
  // Accessibility
  htmlFor?: string;
  className?: string;
}
```

**Implementation Details**:
- Renders container div with `ya-field-group` class
- Conditionally renders label section with `ya-field-group-description` class
- Renders control section with children
- Wraps control in `ya-control-group` when prepend or append is present
- Conditionally renders informative section with `ya-field-group-informative` class
- Applies `ya-field-group-invalid` class when invalid or error is present
- Applies `ya-field-{size}` class based on size prop

**Layout Structure**:
```tsx
<div className="ya-field-group [ya-field-group-invalid] [ya-field-{size}]">
  {/* Label section */}
  {label && (
    <div className="ya-field-group-description">
      <label htmlFor={htmlFor} className="ya-field-group-label">{label}</label>
      {descriptionComplement}
    </div>
  )}
  
  {/* Control section */}
  {(prepend || append) ? (
    <div className="ya-control-group">
      {prepend}
      {children}
      {append}
    </div>
  ) : (
    children
  )}
  
  {/* Informative section */}
  {(information || error || footerAction) && (
    <div className="ya-field-group-informative">
      {error ? (
        <span className="ya-field-information">{errorMessage}</span>
      ) : information ? (
        <span className="ya-field-information">{information}</span>
      ) : null}
      {footerAction && (
        <div className="ya-field-group-footer">{footerAction}</div>
      )}
    </div>
  )}
</div>
```

### FieldText Component

**Purpose**: Simple text wrapper for field layouts.

**Props Interface**:
```typescript
interface FieldTextProps extends React.HTMLAttributes<HTMLDivElement> {
  children: React.ReactNode;
}
```

**Implementation Details**:
- Renders div with `ya-field-text` class
- Spreads all HTML div attributes
- Renders children content

**Implementation**:
```tsx
const FieldText: React.FC<FieldTextProps> = ({ children, className, ...props }) => {
  return (
    <div className={`ya-field-text ${className || ''}`} {...props}>
      {children}
    </div>
  );
};
```

### FieldAction Component

**Purpose**: Action button wrapper for field layouts.

**Props Interface**:
```typescript
interface FieldActionProps {
  label?: string;
  icon?: React.ComponentType<any> | string;
  iconPosition?: 'left' | 'right';
  theme?: 'primary' | 'secondary' | 'success' | 'danger' | 'warning' | 'info';
  outline?: boolean;
  active?: boolean;
  disabled?: boolean;
  onClick?: (event: React.MouseEvent<HTMLButtonElement>) => void;
  className?: string;
}
```

**Implementation Details**:
- Wraps Yasamen Button component
- Adds `ya-field-action` class
- Passes all props to Button component
- Supports all Button features (icon, theme, outline, etc.)

**Implementation**:
```tsx
const FieldAction: React.FC<FieldActionProps> = ({ className, ...props }) => {
  return (
    <Button className={`ya-field-action ${className || ''}`} {...props} />
  );
};
```

### FieldBadge Component

**Purpose**: Badge wrapper for field status indicators.

**Props Interface**:
```typescript
interface FieldBadgeProps {
  text?: string;
  children?: React.ReactNode;
  theme?: 'primary' | 'secondary' | 'success' | 'danger' | 'warning' | 'info';
  className?: string;
}
```

**Implementation Details**:
- Wraps Yasamen Badge component
- Adds `ya-field-badge` class
- Supports text or children for content
- Applies `ya-badge-{theme}` class based on theme prop

**Implementation**:
```tsx
const FieldBadge: React.FC<FieldBadgeProps> = ({ 
  text, 
  children, 
  theme, 
  className, 
  ...props 
}) => {
  return (
    <Badge 
      className={`ya-field-badge ${className || ''}`} 
      theme={theme}
      {...props}
    >
      {text || children}
    </Badge>
  );
};
```

## Data Models

### Error Message Type

```typescript
type ErrorMessage = string | { message?: string } | undefined | null;
```

**Purpose**: Flexible error message type that supports:
- Simple string errors
- React Hook Form error objects with message property
- Formik error objects
- Undefined/null for no error

**Error Extraction Function**:
```typescript
function getErrorMessage(error: ErrorMessage): string | undefined {
  if (!error) return undefined;
  if (typeof error === 'string') return error || undefined;
  if (typeof error === 'object' && 'message' in error) {
    return error.message || undefined;
  }
  return undefined;
}
```

### Size Type

```typescript
type FieldSize = 'smallest' | 'smaller' | 'small' | 'medium' | 'large' | 'larger' | 'largest';
```

**Purpose**: Defines available size variants for fields.

**CSS Class Mapping**:
- `smallest` → `ya-field-smallest`
- `smaller` → `ya-field-smaller`
- `small` → `ya-field-small`
- `medium` → `ya-field-medium` (default)
- `large` → `ya-field-large`
- `larger` → `ya-field-larger`
- `largest` → `ya-field-largest`

### Input Type

```typescript
type InputType = 'text' | 'password' | 'email' | 'number' | 'tel' | 'url';
```

**Purpose**: Defines supported HTML input types.

## Correctness Properties

*A property is a characteristic or behavior that should hold true across all valid executions of a system—essentially, a formal statement about what the system should do. Properties serve as the bridge between human-readable specifications and machine-verifiable correctness guarantees.*


### Property 1: Controlled Input Value and Handler

*For any* value string and onChange handler, when TextField is rendered with these props, the underlying input element should have the value attribute set to the provided value and should call the onChange handler when the input changes.

**Validates: Requirements 1.1**

### Property 2: Input Type Attribute

*For any* valid input type (text, password, email, number, tel, url), when TextField is rendered with that type prop, the underlying input element should have the type attribute set to the provided type.

**Validates: Requirements 1.2**

### Property 3: Label Association

*For any* label string, when TextField is rendered with a label prop, a label element should be rendered with the ya-field-group-label class, and the label's htmlFor attribute should match the input's id attribute.

**Validates: Requirements 1.3, 9.1**

### Property 4: Placeholder Pass-Through

*For any* placeholder string, when TextField is rendered with a placeholder prop, the underlying input element should have the placeholder attribute set to the provided placeholder.

**Validates: Requirements 1.4**

### Property 5: Information Text Display

*For any* information string, when TextField is rendered with an information prop, the information text should be displayed with the ya-field-information class in the informative section.

**Validates: Requirements 1.5**

### Property 6: Error Display and Invalid State

*For any* error value (string or object with message property), when TextField is rendered with an error prop, the error message should be displayed and the input element should have the ya-input-field-invalid CSS class applied.

**Validates: Requirements 1.6, 1.16**

### Property 7: Prepend Content Rendering

*For any* React node provided as prepend prop, when TextField is rendered, the prepend content should appear before the input element within a container with the ya-control-group class.

**Validates: Requirements 1.7**

### Property 8: Append Content Rendering

*For any* React node provided as append prop, when TextField is rendered, the append content should appear after the input element within a container with the ya-control-group class.

**Validates: Requirements 1.8**

### Property 9: Footer Action Rendering

*For any* React node provided as footerAction prop, when TextField is rendered, the footer action content should appear in a section with the ya-field-group-footer class.

**Validates: Requirements 1.9**

### Property 10: Size Class Application

*For any* valid size value (smallest, smaller, small, medium, large, larger, largest), when TextField or FieldGroup is rendered with a size prop, the component should have the ya-field-{size} CSS class applied.

**Validates: Requirements 1.10, 2.12, 14.1, 14.3, 14.4**

### Property 11: MaxLength Attribute

*For any* positive integer maxLength value, when TextField is rendered with a maxLength prop, the underlying input element should have the maxLength attribute set to the provided value.

**Validates: Requirements 1.13**

### Property 12: Ref Forwarding

*For any* ref object, when TextField is rendered with a ref prop, the ref should reference the underlying input DOM element.

**Validates: Requirements 1.14, 6.4**

### Property 13: Base Input CSS Class

*For any* TextField props combination, when TextField is rendered, the underlying input element should always have the ya-input-field CSS class.

**Validates: Requirements 1.15, 10.1**

### Property 14: OnBlur Handler

*For any* onBlur handler function, when TextField is rendered with an onBlur prop and the input is blurred, the onBlur handler should be called with the blur event.

**Validates: Requirements 1.17, 7.5**

### Property 15: FieldGroup Container Class

*For any* FieldGroup props combination, when FieldGroup is rendered, the container element should always have the ya-field-group CSS class.

**Validates: Requirements 2.1, 10.4**

### Property 16: FieldGroup Label Rendering

*For any* label string, when FieldGroup is rendered with a label prop, a label element should be rendered with the ya-field-group-label class.

**Validates: Requirements 2.2, 10.6**

### Property 17: Label For Attribute

*For any* label and htmlFor combination, when FieldGroup is rendered with both props, the label element's for attribute should match the provided htmlFor value.

**Validates: Requirements 2.3**

### Property 18: Description Complement Rendering

*For any* React node provided as descriptionComplement prop, when FieldGroup is rendered, the description complement should appear in the description section next to the label.

**Validates: Requirements 2.4**

### Property 19: FieldGroup Prepend Rendering

*For any* React node provided as prepend prop, when FieldGroup is rendered, the prepend content should appear before the children within a container with the ya-control-group class.

**Validates: Requirements 2.5**

### Property 20: FieldGroup Append Rendering

*For any* React node provided as append prop, when FieldGroup is rendered, the append content should appear after the children within a container with the ya-control-group class.

**Validates: Requirements 2.6**

### Property 21: FieldGroup Children Rendering

*For any* React node provided as children, when FieldGroup is rendered, the children should be rendered in the control section.

**Validates: Requirements 2.7, 11.1**

### Property 22: FieldGroup Information Display

*For any* information string, when FieldGroup is rendered with an information prop, the information text should be displayed with the ya-field-information class.

**Validates: Requirements 2.8, 10.9**

### Property 23: FieldGroup Error Display

*For any* error value (string or object with message property), when FieldGroup is rendered with an error prop, the error message should be displayed in the informative section.

**Validates: Requirements 2.9**

### Property 24: FieldGroup Invalid State

*For any* error value, when FieldGroup is rendered with an error prop, the container should have the ya-field-group-invalid CSS class applied.

**Validates: Requirements 2.10, 10.5**

### Property 25: FieldGroup Footer Action

*For any* React node provided as footerAction prop, when FieldGroup is rendered, the footer action should appear in a section with the ya-field-group-footer class.

**Validates: Requirements 2.11, 10.10, 11.2**

### Property 26: FieldGroup Description Section Class

*For any* FieldGroup with a label prop, when rendered, the description section should have the ya-field-group-description CSS class.

**Validates: Requirements 2.14, 10.7**

### Property 27: FieldGroup Informative Section Class

*For any* FieldGroup with information, error, or footerAction props, when rendered, the informative section should have the ya-field-group-informative CSS class.

**Validates: Requirements 2.15, 10.8**

### Property 28: FieldText Base Class

*For any* FieldText props combination, when FieldText is rendered, it should render a div element with the ya-field-text CSS class.

**Validates: Requirements 3.1, 10.11**

### Property 29: FieldText Children Rendering

*For any* React node provided as children, when FieldText is rendered, the children should be rendered inside the div element.

**Validates: Requirements 3.2**

### Property 30: FieldText Attribute Pass-Through

*For any* valid HTML div attributes, when FieldText is rendered with those attributes, they should be applied to the div element.

**Validates: Requirements 3.3**

### Property 31: FieldAction Base Class

*For any* FieldAction props combination, when FieldAction is rendered, it should render a button element with the ya-field-action CSS class.

**Validates: Requirements 4.1, 10.12**

### Property 32: FieldAction Label Display

*For any* label string, when FieldAction is rendered with a label prop, the label text should appear in the button.

**Validates: Requirements 4.2**

### Property 33: FieldAction Icon Display

*For any* icon component or string, when FieldAction is rendered with an icon prop, the icon should be rendered in the button.

**Validates: Requirements 4.3**

### Property 34: FieldAction Icon Position

*For any* iconPosition value (left or right), when FieldAction is rendered with an icon and iconPosition prop, the icon should be positioned according to the iconPosition value.

**Validates: Requirements 4.4**

### Property 35: FieldAction Theme Styling

*For any* valid theme value, when FieldAction is rendered with a theme prop, the appropriate theme styling should be applied to the button.

**Validates: Requirements 4.5**

### Property 36: FieldAction Click Handler

*For any* onClick handler function, when FieldAction is rendered with an onClick prop and the button is clicked, the onClick handler should be called with the click event.

**Validates: Requirements 4.9**

### Property 37: FieldBadge Base Class

*For any* FieldBadge props combination, when FieldBadge is rendered, it should render a badge element with the ya-field-badge CSS class.

**Validates: Requirements 5.1, 10.13**

### Property 38: FieldBadge Text Display

*For any* text string, when FieldBadge is rendered with a text prop, the text should appear in the badge.

**Validates: Requirements 5.2**

### Property 39: FieldBadge Children Display

*For any* React node provided as children, when FieldBadge is rendered with children, the children should be rendered in the badge.

**Validates: Requirements 5.3**

### Property 40: FieldBadge Theme Styling

*For any* valid theme value, when FieldBadge is rendered with a theme prop, the ya-badge-{theme} CSS class should be applied.

**Validates: Requirements 5.4, 5.5**

### Property 41: React Hook Form Error Handling

*For any* React Hook Form error object with a message property, when TextField is rendered with the error, both the error message should be displayed and the ya-input-field-invalid class should be applied.

**Validates: Requirements 6.2, 6.3**

### Property 42: Name Prop Support

*For any* name string, when TextField is rendered with a name prop, the underlying input element should have the name attribute set to the provided name.

**Validates: Requirements 6.5, 7.4**

### Property 43: Formik Error Handling

*For any* Formik error value, when TextField is rendered with the error, both the error message should be displayed and the ya-input-field-invalid class should be applied.

**Validates: Requirements 7.2, 7.3**

### Property 44: Error Accessibility Attributes

*For any* error value, when TextField is rendered with an error prop, the input element should have aria-invalid="true" and aria-describedby should reference the error message element.

**Validates: Requirements 9.2, 9.3**

### Property 45: Information Accessibility

*For any* information string, when TextField is rendered with an information prop, the input element's aria-describedby should reference the information text element.

**Validates: Requirements 9.4**

### Property 46: FieldAction Keyboard Accessibility

*For any* onClick handler, when FieldAction is rendered and Enter or Space key is pressed while focused, the onClick handler should be called.

**Validates: Requirements 9.7**

### Property 47: Control Group CSS Class

*For any* TextField or FieldGroup with prepend or append props, when rendered, the control section should have the ya-control-group CSS class.

**Validates: Requirements 10.14, 13.4**

### Property 48: Error Message Extraction

*For any* error value (string, object with message, undefined, null, or empty string), when passed to the error extraction function, it should return the correct error message string or undefined.

**Validates: Requirements 12.1, 12.2**

### Property 49: Error Message Location

*For any* error value, when TextField or FieldGroup is rendered with an error prop, the error message should appear in the informative section below the control.

**Validates: Requirements 12.5**

### Property 50: Error Takes Precedence Over Information

*For any* combination of error and information props, when both are provided to TextField or FieldGroup, the error message should be displayed and the information text should not be displayed.

**Validates: Requirements 12.7**

### Property 51: Prepend and Append Order

*For any* combination of prepend and append React nodes, when TextField or FieldGroup is rendered with both props, the rendering order should be: prepend, input/children, append.

**Validates: Requirements 13.3**

### Property 52: Content Rendering Without Wrappers

*For any* prepend or append React node, when rendered in TextField or FieldGroup, the content should be rendered directly without additional wrapper elements between the control group and the content.

**Validates: Requirements 13.5, 13.6**

## Error Handling

### Error Message Normalization

All components that accept error props use a common error normalization function:

```typescript
function getErrorMessage(error: ErrorMessage): string | undefined {
  if (!error) return undefined;
  if (typeof error === 'string') return error || undefined;
  if (typeof error === 'object' && 'message' in error) {
    return error.message || undefined;
  }
  return undefined;
}
```

This function handles:
- String errors (direct display)
- React Hook Form errors (object with message property)
- Formik errors (object with message property)
- Undefined/null (no error)
- Empty strings (treated as no error)

### Invalid State Handling

When an error is present (after normalization):
1. Apply `ya-input-field-invalid` class to input element
2. Apply `ya-field-group-invalid` class to FieldGroup container
3. Set `aria-invalid="true"` on input element
4. Set `aria-describedby` to reference error message element
5. Display error message in informative section

### Error Display Priority

When both error and information props are provided:
1. Display error message (not information text)
2. Apply invalid state styling
3. Set aria-describedby to error message (not information)
4. Information text is hidden when error is present

### Accessibility Error Handling

Error messages are associated with inputs using:
- `aria-invalid="true"` attribute on input
- `aria-describedby` attribute referencing error message element ID
- Unique IDs generated for error message elements
- Error messages are announced by screen readers when field receives focus

## Testing Strategy

### Dual Testing Approach

This feature requires both unit tests and property-based tests for comprehensive coverage:

**Unit Tests** focus on:
- Specific examples of component rendering
- Edge cases (disabled, readonly, empty values)
- Integration with React Hook Form and Formik
- Accessibility attributes
- CSS class application
- Event handler invocation

**Property-Based Tests** focus on:
- Universal properties across all input values
- Random prop combinations
- Error handling across all error types
- Content rendering with random React nodes
- CSS class application across all size/theme variants
- Ref forwarding with random ref objects

### Property-Based Testing Configuration

**Library**: Use `@fast-check/jest` for TypeScript/React property-based testing

**Test Configuration**:
- Minimum 100 iterations per property test
- Each test references its design document property
- Tag format: `Feature: react-forms-components, Property {number}: {property_text}`

**Generators Needed**:
- String generator (for labels, placeholders, information, errors)
- Input type generator (text, password, email, number, tel, url)
- Size generator (smallest, smaller, small, medium, large, larger, largest)
- Theme generator (primary, secondary, success, danger, warning, info)
- React node generator (for prepend, append, footerAction, children)
- Error object generator (string, object with message, undefined, null, empty string)
- Event handler generator (mock functions)
- Ref object generator (React.createRef())

### Unit Test Examples

```typescript
// Example: Disabled state
test('TextField with disabled=true should disable input', () => {
  const { getByRole } = render(<TextField label="Test" disabled />);
  expect(getByRole('textbox')).toBeDisabled();
});

// Example: React Hook Form integration
test('TextField with register props should work with React Hook Form', () => {
  const { register } = useForm();
  const { getByRole } = render(
    <TextField label="Test" {...register('test')} />
  );
  expect(getByRole('textbox')).toHaveAttribute('name', 'test');
});
```

### Property Test Examples

```typescript
// Example: Property 3 - Label Association
test('Property 3: Label Association', () => {
  fc.assert(
    fc.property(fc.string(), (label) => {
      const { getByLabelText, getByRole } = render(
        <TextField label={label} />
      );
      const input = getByRole('textbox');
      const labelElement = getByLabelText(label);
      expect(labelElement).toHaveAttribute('for', input.id);
    }),
    { numRuns: 100 }
  );
});

// Example: Property 6 - Error Display and Invalid State
test('Property 6: Error Display and Invalid State', () => {
  fc.assert(
    fc.property(
      fc.oneof(
        fc.string({ minLength: 1 }),
        fc.record({ message: fc.string({ minLength: 1 }) })
      ),
      (error) => {
        const { getByRole, getByText } = render(
          <TextField label="Test" error={error} />
        );
        const input = getByRole('textbox');
        const errorMessage = typeof error === 'string' ? error : error.message;
        expect(getByText(errorMessage)).toBeInTheDocument();
        expect(input).toHaveClass('ya-input-field-invalid');
      }
    ),
    { numRuns: 100 }
  );
});
```

### Testing Coverage Goals

- 100% of correctness properties implemented as property-based tests
- Unit tests for all edge cases and specific examples
- Integration tests for React Hook Form and Formik
- Accessibility tests using jest-axe
- Visual regression tests for CSS styling (optional)
- Cross-browser compatibility tests (optional)

### Test Organization

```
src/
  components/
    TextField/
      TextField.tsx
      TextField.test.tsx (unit tests)
      TextField.properties.test.tsx (property-based tests)
    FieldGroup/
      FieldGroup.tsx
      FieldGroup.test.tsx
      FieldGroup.properties.test.tsx
    FieldText/
      FieldText.tsx
      FieldText.test.tsx
    FieldAction/
      FieldAction.tsx
      FieldAction.test.tsx
    FieldBadge/
      FieldBadge.tsx
      FieldBadge.test.tsx
  utils/
    errorHandling.ts
    errorHandling.test.tsx
    errorHandling.properties.test.tsx
```
