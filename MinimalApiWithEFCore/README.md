### Apontamento

~~~c#
modelBuilder.Entity<Customer>()
.HasMany(c => c.Orders)
.WithOne(o => o.Customer)
.HasForeignKey(o => o.CustomerId)
.IsRequired();
~~~
